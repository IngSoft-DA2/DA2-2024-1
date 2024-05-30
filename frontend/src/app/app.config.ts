import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { TestService } from './test.service';
import { AuthService } from './services/auth.service';
import { SessionStorageService } from './services/session-storage.service';
import { HTTP_INTERCEPTORS, provideHttpClient } from '@angular/common/http';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { APIInterceptor } from './interceptors/apiInterceptor';
import { ImportersService } from './services/importers.service';
import { AuthGuard } from './guards/auth.guard';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    TestService,
    AuthService,
    ImportersService,
    AuthGuard,
    SessionStorageService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: APIInterceptor,
      multi: true
    },
  ],
};
