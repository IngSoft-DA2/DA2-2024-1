import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { TestService } from './test.service';
import { AuthService } from './services/auth.service';
import { SessionStorageService } from './services/session-storage.service';
import { HTTP_INTERCEPTORS, provideHttpClient } from '@angular/common/http';
import { UnServicioService } from './un-servicio.service';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { APIInterceptor } from './interceptors/apiInterceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    TestService,
    AuthService,
    UnServicioService,
    SessionStorageService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: APIInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
};
