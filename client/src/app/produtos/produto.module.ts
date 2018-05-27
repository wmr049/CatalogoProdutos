import { NgModule } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

// modules
import { MyDatePickerModule } from 'mydatepicker';

// components
import { ProdutoComponent } from './produto.component';
import { ListaProdutosComponent } from './lista-produtos/lista-produtos.component';

// services
import { SeoService } from '../services/seo.service';
import { ProdutoService } from './services/produto.service';
import { UsuarioService } from '../services/usuario.service';
import { AuthService } from './services/auth.service';
import { ErrorInterceptor } from '../services/error-handler.service';

// config
import { produtosRouterConfig } from './produto.routes';

// my modules
import { SharedModule } from '../shared/shared.module';

@NgModule({
    imports: [
        SharedModule,
        CommonModule,
        FormsModule,
        RouterModule.forChild(produtosRouterConfig),
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule,
        MyDatePickerModule,
    ],
    declarations: [
        ProdutoComponent,
        ListaProdutosComponent,
    ],
    providers: [
        Title,
        SeoService,
        ProdutoService,
        UsuarioService,
        AuthService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: ErrorInterceptor,
            multi: true
        }
    ],
    exports: [RouterModule]
})

export class ProdutosModule { }
