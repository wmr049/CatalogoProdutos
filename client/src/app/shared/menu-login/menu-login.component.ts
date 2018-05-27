import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu-login',
  templateUrl: './menu-login.component.html'
})
export class MenuLoginComponent {

  public token;
  public user;
  public nome = '';

  constructor(private router: Router) { }

  usuarioLogado(): boolean {

    this.token = localStorage.getItem('cp.token');
    this.user = JSON.parse(localStorage.getItem('cp.user'));

    if (this.user) {
      this.nome = this.user.nome;
    }

    return this.token !== null;
  }

  logout() {

    localStorage.removeItem('cp.token');
    localStorage.removeItem('cp.user');

    this.router.navigate(['/entrar']);
  }
}
