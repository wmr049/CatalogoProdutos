import { Component, OnInit, AfterViewInit, OnDestroy, ViewChildren, ElementRef, ViewContainerRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/observable/fromEvent';
import 'rxjs/add/observable/merge';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormControl, FormArray, Validators, FormControlName } from '@angular/forms';
import { SeoService, SeoModel } from '../../services/seo.service';
import { ToastrService, Toast } from 'ngx-toastr';
import { Produto } from '../models/produto';
import { ProdutoService } from '../services/produto.service';
import { GenericValidator } from '../../common/validation/generic-form-validator';

@Component({
    selector: 'app-lista-produtos',
    templateUrl: './lista-produtos.component.html',
    styleUrls: ['./lista-produtos.component.css']
})
export class ListaProdutosComponent implements OnInit, AfterViewInit {
    @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

    public produtos: Produto[];
    produto: Produto;
    produtoId = '';
    errorMessage: string;
    produtoForm: FormGroup;
    public errorsProduto: any[] = [];
    private modalVisible: boolean;

    constructor(seoService: SeoService,
        private fb: FormBuilder,
        public produtoService: ProdutoService,
        public toastr: ToastrService,
        vcr: ViewContainerRef) {

        const seoModel: SeoModel = <SeoModel>{
            title: 'Catalogo de Produtos',
            description: 'Lista dos produtos cadastrados',
            robots: 'Index, Follow',
            keywords: 'produtos,gerenciador,catalogo'
        };

        this.validationMessages = {
            nome: {
                required: 'O Nome é requerido.',
                minlength: 'O Nome precisa ter no mínimo 2 caracteres',
                maxlength: 'O Nome precisa ter no máximo 150 caracteres'
            },
            descricao: {
                required: 'Informe a descrição de início',
                minlength: 'O descrição precisa ter no mínimo 2 caracteres',
                maxlength: 'O descrição precisa ter no máximo 150 caracteres'
            },
            preco: {
                required: 'Informe o preço'
            }
        };

        this.genericValidator = new GenericValidator(this.validationMessages);
        this.produto = new Produto();

        this.modalVisible = false;
        seoService.setSeoData(seoModel);
    }

    displayMessage: { [key: string]: string } = {};
    private validationMessages: { [key: string]: { [key: string]: string } };
    private genericValidator: GenericValidator;

    adicionarProduto() {
        if (this.produtoForm.dirty && this.produtoForm.valid) {
            const p = Object.assign({}, this.produto, this.produtoForm.value);

            this.produtoService.registrarProduto(p)
            .subscribe(
                result => { this.onProdutoSaveComplete(); },
                error => {
                    this.errorsProduto = JSON.parse(error._body).errors;
                });
            }
    }

    onProdutoSaveComplete(): void {
        this.hideModal();

        this.toastr.success('Prodto adicionado', 'Oba :D');
    }

    public showModal(): void {
        this.modalVisible = true;
    }

    public hideModal(): void {
        this.modalVisible = false;
    }

    ngOnInit(): void {
        this.produtoForm = this.fb.group({
            nome: ['', [Validators.required,
            Validators.minLength(2),
            Validators.maxLength(150)]],
            descricao: ['', Validators.required],
            preco: [0, Validators.required],
        });

        this.produtoService.obterTodos()
            .subscribe(produtos => this.produtos = produtos,
                error => this.errorMessage);
    }

    ngAfterViewInit(): void {
        const controlBlurs: Observable<any>[] = this.formInputElements
            .map((formControl: ElementRef) => Observable.fromEvent(formControl.nativeElement, 'blur'));

        Observable.merge(...controlBlurs).debounceTime(100).subscribe(value => {
            this.displayMessage = this.genericValidator.processMessages(this.produtoForm);
        });
    }
}
