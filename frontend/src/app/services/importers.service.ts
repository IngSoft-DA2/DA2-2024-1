import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ImporterEndpoints, SessionEndpoints } from '../networking/endpoints';
interface IAuthService {
  getImporters(): Observable<any>;
}

@Injectable({
  providedIn: 'root',
})
export class ImportersService implements IAuthService {
  constructor(private _httpClient: HttpClient) {}

  getImporters(): Observable<any> {
    return this._httpClient.get(
     ImporterEndpoints.GET_ALL
    );
  }
}
