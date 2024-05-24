import { Injectable } from '@angular/core';
import { LoginReturnModel } from './types';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { SessionEndpoints } from '../networking/endpoints';
import { serializeLoginBody } from './helpers';
interface IAuthService {
  login(name: string, password: string): Observable<LoginReturnModel>;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService implements IAuthService {
  constructor(private _httpClient: HttpClient) {}

  login(name: string, password: string): Observable<LoginReturnModel> {
    // Utilizando http comunciarnos con nuestra api
    // Vamos a tener que especificar nuestra BASE_URL ->  http://localhost:5051
    // Vamos a tener que utilizar los endpoints que definimos recien  para comunicarnos en realidad
    // Retornar un Observable
    // axios -> post/put/get/delete
    // En angular tenemos el HttpClient
    // post a http://localhost:5051/api/session con body { name y password }
    const body = serializeLoginBody(name, password);
    return this._httpClient.post<LoginReturnModel>(
      // http://localhost:5051/api/sessions
      SessionEndpoints.LOGIN,
      { name, password }
    );
  }
}
