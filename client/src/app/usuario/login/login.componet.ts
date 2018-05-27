import { Component, OnInit, AfterViewInit, OnDestroy, ViewChildren, ElementRef, ViewContainerRef } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormControl, FormArray, Validators, FormControlName } from '@angular/forms';

import { Router } from '@angular/router';

import { GenericValidator } from '../../common/validation/generic-form-validator';
import { ToastrService, Toast } from 'ngx-toastr';
import { CustomValidators, CustomFormsModule } from 'ng2-validation';

import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/observable/fromEvent';
import 'rxjs/add/observable/merge';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';

import { UsuarioService } from '../../services/usuario.service';
import { Usuario } from '../models/usuario';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit, AfterViewInit {
    @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

    public errors: any[] = [];
    loginForm: FormGroup;
    usuario: Usuario;

    constructor(private fb: FormBuilder,
        private usuarioService: UsuarioService,
        private router: Router,
        private toastr: ToastrService,
        vcr: ViewContainerRef) {

        this.validationMessages = {
            email: {
                required: 'Informe o e-mail',
                email: 'Email invalido'
            },
            password: {
                required: 'Informe a senha',
                minlength: 'A senha deve possuir no mínimo 6 caracteres'
            }
        };

        this.genericValidator = new GenericValidator(this.validationMessages);
        this.usuario = new Usuario();
    }

    displayMessage: { [key: string]: string } = {};
    private validationMessages: { [key: string]: { [key: string]: string } };
    private genericValidator: GenericValidator;

    ngOnInit(): void {
        this.loginForm = this.fb.group({

            email: ['', [Validators.required, CustomValidators.email]],
            password: ['', [Validators.required, Validators.minLength(6)]],
        });
    }

    ngAfterViewInit(): void {
        const controlBlurs: Observable<any>[] = this.formInputElements
            .map((formControl: ElementRef) => Observable.fromEvent(formControl.nativeElement, 'blur'));

        Observable.merge(...controlBlurs).subscribe(value => {
            this.displayMessage = this.genericValidator.processMessages(this.loginForm);
        });
    }

    login() {
        if (this.loginForm.dirty && this.loginForm.valid) {
            const p = Object.assign({}, this.usuario, this.loginForm.value);

            this.usuarioService.login(p)
                .subscribe(
                    result => { this.onSaveComplete(result); },
                    fail => { this.onError(fail); }
                );
        }
    }

    onSaveComplete(response: any): void {
        this.loginForm.reset();
        this.errors = [];

        localStorage.setItem('cp.token', response.result.access_token);
        localStorage.setItem('cp.user', JSON.stringify(response.result.user));

        this.toastr.success('Login efetuado com sucesso', 'Bem vindo!!!', { tapToDismiss: true, timeOut: 3000 })
            .onHidden.subscribe((action) =>
                this.router.navigate(['/produtos'])
        );
    }

    onError(fail: any) {
        this.toastr.error('Ocorreu um erro!', 'Opa :(');
        this.errors = fail.error.errors;
    }
}
