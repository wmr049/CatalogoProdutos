import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { rootRouterConfig } from './app.routes';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// Locales
import { registerLocaleData, CommonModule } from '@angular/common';
import localePt from '@angular/common/locales/pt';
registerLocaleData(localePt);

// Modules
import { ToastrModule } from 'ngx-toastr';

// bootstrap
import { AlertModule } from 'ngx-bootstrap';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { CarouselModule } from 'ngx-bootstrap/carousel';

// shared
import { AcessoNegadoComponent } from './shared/acesso-negado/acesso-negado.component';
import { NaoEncontradoComponent } from './shared/nao-encontrado/nao-encontrado.component';

// components
import { LoginComponent } from './usuario/login/login.componet';
import { AppComponent } from './app.component';
import { ProdutoComponent } from './produtos/produto.component';

// services
import { SeoService } from './services/seo.service';
import { UsuarioService } from './services/usuario.service';
import { ErrorInterceptor } from './services/error-handler.service';

// modules
import { SharedModule } from './shared/shared.module';
import { ProdutosModule } from './produtos/produto.module';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AcessoNegadoComponent,
    NaoEncontradoComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    // ProdutosModule,
    SharedModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    AlertModule.forRoot(),
    CollapseModule.forRoot(),
    CarouselModule.forRoot(),
    RouterModule.forRoot(rootRouterConfig, { useHash: false })
  ],
  providers: [
    Title,
    SeoService,
    UsuarioService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true
    },
    {
      provide: LOCALE_ID,
      useValue: 'pt'
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
