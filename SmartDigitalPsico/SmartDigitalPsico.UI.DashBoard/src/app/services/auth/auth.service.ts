import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { GenericService } from '../generic/generic.service';
import { ServiceResponse } from 'app/models/ServiceResponse';
import { environment } from 'environments/environment';
import { UserAutenticateModel, UserLoginModel } from 'app/models/UserLoginModel';

//'https://localhost:61949/api/Auth/v1/Login
const basePathUrl = '/Auth/v1';
@Injectable()
export class AuthService extends GenericService<ServiceResponse<UserAutenticateModel>, UserLoginModel, number> {

  constructor(@Inject(HttpClient) http: HttpClient) {

    super(http, `${environment.APIUrl + basePathUrl}`, '/');
  }

  login(credentials: UserLoginModel) {
    let urlAut = `${environment.APIUrl + basePathUrl}/authenticate`;
    //urlAut = '/api/authenticate'//Test Mock
    return this.httpLocal.post(urlAut, JSON.stringify(credentials));
  }

  logout() {
  }

  isLoggedIn() {
    return false;
  }

}
