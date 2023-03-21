import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { GenericService } from '../generic/generic.service';
import { ServiceResponse } from 'app/models/ServiceResponse';
import { environment } from 'environments/environment';
import { UserAutenticateModel, UserLoginModel } from 'app/models/UserLoginModel';
import { catchError, map, throwError } from 'rxjs';
import { AppError } from 'app/common/app-error';
import { Token } from '@angular/compiler';
import { JwtHelperService } from '@auth0/angular-jwt';

//'https://localhost:61949/api/Auth/v1/Login
const basePathUrl = '/Auth/v1';
@Injectable()
export class AuthService extends GenericService<ServiceResponse<UserAutenticateModel>, UserLoginModel, number> {

  private keyLocalStorage: string = "tokenjwt";

  constructor(@Inject(HttpClient) http: HttpClient) {

    super(http, `${environment.APIUrl + basePathUrl}`, '/');
  }

  login(credentials: UserLoginModel) {
    let urlAut = `${environment.APIUrl + basePathUrl}/authenticate`;
    console.log(urlAut);
    //urlAut = '/api/authenticate'//Test Mock
    //JSON.stringify(credentials) 
    return this.httpLocal.post<ServiceResponse<UserAutenticateModel>>(urlAut, credentials).pipe(map(response => {
      console.log(response);
      let userAutenticate = response?.data;
      let token = userAutenticate.tokenAuth;
      if (token && token?.authenticated && token.accessToken) {
        localStorage.setItem(this.keyLocalStorage, token.accessToken);
        return true;
      }
      return false;
    }), catchError(this.customHandleErrorAuthService));
  }

  logout() {
    localStorage.removeItem(this.keyLocalStorage);
  }

  isLoggedIn() {
    let sessionTokenActive = false;
    sessionTokenActive = this.checkTokenJWT();
    return sessionTokenActive;
  }

  private checkTokenJWT(): boolean {
    let sessionTokenActive = false;
    let cacheTokenLS: string = localStorage.getItem(this.keyLocalStorage);
    if (!cacheTokenLS) return sessionTokenActive;

    if (cacheTokenLS && cacheTokenLS != '') {
      sessionTokenActive = true;

      let jwtHelper = new JwtHelperService(cacheTokenLS);
      let expirationDate = jwtHelper.getTokenExpirationDate(cacheTokenLS);
      let isTokenExpired = jwtHelper.isTokenExpired(cacheTokenLS);   
      sessionTokenActive = !isTokenExpired;
    }
    return sessionTokenActive;
  }

  private customHandleErrorAuthService(error: Response) {
    console.log('customHandleError-AuthService');
    /*if (error.status === 400)
      return throwError(() => new BadInput(error.json()));

    if (error.status === 404)
      return throwError(() => new NotFoundError());
*/
    //return Observable.throw(new AppError(error));
    // Return an observable with a user-facing error message.
    return throwError(() => new AppError(error));
  }

}
