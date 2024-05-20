import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { TestService } from './test.service';
import { AuthService } from './services/auth.service';
import { SessionStorageService } from './services/session-storage.service';
import { provideHttpClient } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    TestService,
    AuthService,
    SessionStorageService,
  ],
};
