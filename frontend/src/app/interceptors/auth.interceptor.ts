import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { SessionStorageService } from '../services/session-storage.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private _sessionStorageService: SessionStorageService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    // Obtener el token del session storage / local storage
    const token = this._sessionStorageService.getToken();

    let newRequest = request;

    // Si estoy pegandole al endpoint login, no hago nada
    if (request.url.includes('login')) {
      return next.handle(request);
    }

    if (!!token) {
      const headers = request.headers.set('Authorization', token);
      newRequest = request.clone({ headers });
    }

    return next.handle(newRequest);
  }
}
