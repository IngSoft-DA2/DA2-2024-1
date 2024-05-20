import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { SessionStorageService } from '../services/session-storage.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  showPassword: boolean = false;

  constructor(
    private _authService: AuthService,
    private _router: Router,
    private _sessionStorageService: SessionStorageService
  ) {}

  login() {
    this._authService.login(this.email, this.password).subscribe((response) => {
      console.log('response', response.token);
      this._sessionStorageService.setToken(response.token);
      this._router.navigate(['/home']);
    });
  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }
}
