import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SessionStorageService {
  private _userTokenKey = 'userToken';

  constructor() {}

  public getToken(): string | null {
    return sessionStorage.getItem(this._userTokenKey);
  }

  public setToken(token: string): void {
    sessionStorage.setItem(this._userTokenKey, token);
  }

  public removeToken(): void {
    sessionStorage.removeItem(this._userTokenKey);
  }
}
