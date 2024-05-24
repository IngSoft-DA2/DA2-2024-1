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
    const token = this._sessionStorageService.getToken();
    let newRequest = request;
    console.log('request', request);
    if (request.url.includes('login')) {
      return next.handle(request);
    }

    if (!!token) {
      // const headers = request.headers.set('Authorization', `Bearer ${token}`);
      const headers = request.headers.set('Authorization', token);
      newRequest = request.clone({ headers });
    }
    return next.handle(newRequest);
  }
}
