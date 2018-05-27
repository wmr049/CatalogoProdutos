import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

import { BaseService } from '../../services/base.service';
import { Produto } from '../models/produto';

@Injectable()
export class ProdutoService extends BaseService {
    constructor(private http: HttpClient) { super(); }

    registrarProduto(produto: Produto): Observable<Produto> {

        const response = this.http
            .post(this.UrlServiceV1 + 'produtos', produto, super.ObterAuthHeaderJson())
            .map(super.extractData)
            .catch(super.serviceError);

        return response;
    }

    obterTodos(): Observable<Produto[]> {
        return this.http
            .get<Produto[]>(this.UrlServiceV1 + 'produtos', super.ObterAuthHeaderJson())
            .catch(super.serviceError);
    }

    obterProduto(id: string): Observable<Produto> {
        return this.http
            .get<Produto>(this.UrlServiceV1 + 'produtos/' + id)
            .catch(super.serviceError);
    }

    atualizarProduto(produto: Produto): Observable<Produto> {
        const response = this.http
            .put(this.UrlServiceV1 + 'produtos', produto, super.ObterAuthHeaderJson())
            .map(super.extractData)
            .catch((super.serviceError));
        return response;
    }

    excluirProduto(id: string): Observable<Produto> {
        const response = this.http
            .delete(this.UrlServiceV1 + 'produtos/' + id, super.ObterAuthHeaderJson())
            .map(super.extractData)
            .catch((super.serviceError));
        return response;
    }
}
