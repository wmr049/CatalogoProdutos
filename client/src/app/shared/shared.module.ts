import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

// bootstrap
import { CollapseModule } from 'ngx-bootstrap/collapse';

//
import { SafePipe } from '../common/pipes/safeurl.pipe';

// components
import { MenuSuperiorComponent } from './menu-superior/menu-superior.component';
import { FooterComponent } from './footer/footer.component';
import { MenuLoginComponent } from './menu-login/menu-login.component';
import { AcessoNegadoComponent } from './acesso-negado/acesso-negado.component';
import { NaoEncontradoComponent } from './nao-encontrado/nao-encontrado.component';

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        CollapseModule
        ],
    declarations: [
        MenuSuperiorComponent,
        FooterComponent,
        MenuLoginComponent,
        NaoEncontradoComponent,
        SafePipe
        ],
    exports: [
        MenuSuperiorComponent,
        FooterComponent,
        MenuLoginComponent,
        SafePipe
        ]
})
export class SharedModule { }
