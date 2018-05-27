import { Routes } from '@angular/router';
import { LoginComponent } from './usuario/login/login.componet';
import { AcessoNegadoComponent } from './shared/acesso-negado/acesso-negado.component';
import { NaoEncontradoComponent } from './shared/nao-encontrado/nao-encontrado.component';

export const rootRouterConfig: Routes = [
    { path: '', component: LoginComponent },
    { path: 'acesso-negado', component: AcessoNegadoComponent },
    { path: 'nao-encontrado', component: NaoEncontradoComponent },
    { path: 'entrar', component: LoginComponent },
    { path: 'produtos', loadChildren: './produtos/produto.module#ProdutosModule' },
];
