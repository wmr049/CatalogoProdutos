import { Routes } from '@angular/router';
import { ProdutoComponent } from './produto.component';

import { AuthService } from './services/auth.service';
import { ListaProdutosComponent } from './lista-produtos/lista-produtos.component';

export const produtosRouterConfig: Routes = [
    {
        path: '', component: ProdutoComponent,
        children: [
            { path: '', component: ListaProdutosComponent },
            { path: 'lista-produtos', component: ListaProdutosComponent },
        ]
    }
];
