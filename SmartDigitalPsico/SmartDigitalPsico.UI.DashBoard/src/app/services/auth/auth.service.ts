import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { GenericService } from '../generic/generic.service';
import { ServiceResponse } from 'app/models/ServiceResponse';
import { environment } from 'environments/environment';
import { RoleGroup, TokenAuth, UserAutenticateModel, UserAutenticateView, UserLoginModel } from 'app/models/UserLoginModel';
import { catchError, map, throwError } from 'rxjs';
import { AppError } from 'app/common/app-error';
import { JwtHelperService } from '@auth0/angular-jwt';

//'https://localhost:61949/api/Auth/v1/Login
const basePathUrl = '/Auth/v1';
@Injectable()
export class AuthService extends GenericService<ServiceResponse<UserAutenticateModel>, UserLoginModel, number> {
  private keyLocalStorage: string = "tokenjwt";
  private userAutenticate: UserAutenticateModel;

  constructor(@Inject(HttpClient) http: HttpClient) {
    super(http, `${environment.APIUrl + basePathUrl}`, '/');
  }
  login(credentials: UserLoginModel) {
    let urlAut = `${environment.APIUrl + basePathUrl}/authenticate`;
    //urlAut = '/api/authenticate'//Test Mock
    //JSON.stringify(credentials) 
    return this.httpLocal.post<ServiceResponse<UserAutenticateModel>>(urlAut, credentials).pipe(map(response => {
      return this.processLoginApi(response);
    }), catchError(this.customHandleErrorAuthService));
  }
  processLoginApi(response: ServiceResponse<UserAutenticateModel>) {
    //console.log(response);
    this.userAutenticate = response?.data;
    let token = this.userAutenticate.tokenAuth;
    if (token && token?.authenticated && token.accessToken) {
      this.setLocalStorageUser(token);
      return true;
    }
    return false;
  }
  setLocalStorageUser(token: TokenAuth): void {
    const userLogged = this.userAutenticate;
    localStorage.setItem(this.keyLocalStorage, token.accessToken);
    //console.log(this.userAutenticate); 
    let userCache: UserAutenticateView = {
      id: userLogged.id,
      name: userLogged.name,
      roleGroups: userLogged.roleGroups
    };
    const strUserAutenticate = JSON.stringify(userCache);
    //console.log(strUserAutenticate);
    localStorage.setItem(this.keyLocalStorage + '_user', strUserAutenticate);
  }
  getLocalStorageUser(): UserAutenticateView {
    const strUserAutenticate = localStorage.getItem(this.keyLocalStorage + '_user');
    //console.log(strUserAutenticate);
    let userLoaded: UserAutenticateView
    userLoaded = JSON.parse(strUserAutenticate);
    //console.log(userLoaded);
    return userLoaded;
  }
  getRolesUser(): RoleGroup[] {
    let userLoaded: UserAutenticateView = this.getLocalStorageUser();
   
    if (userLoaded != null && userLoaded != undefined)
      return userLoaded?.roleGroups;

      return null;
  }

  isUserContainsRole(roleCheck: string): boolean {
    let isUserContainRole: boolean = false;
    const userRoles: RoleGroup[] = this.getRolesUser();
    //const roleFinded: RoleGroup = userRoles.find(role => role?.rolePolicyClaimCode?.toUpperCase().trim() == roleCheck?.toUpperCase().trim());    
    //if (roleFinded) { isUserContainRole = true };
    if (userRoles != null && userRoles != undefined)
      isUserContainRole = userRoles?.some(role => role?.rolePolicyClaimCode === roleCheck);

    return isUserContainRole;
  }

  removeLocalStorageUser() {
    localStorage.removeItem(this.keyLocalStorage);
    localStorage.removeItem(this.keyLocalStorage + '_user');
  }
  logout() {
    this.removeLocalStorageUser();
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
    //console.log('customHandleError-AuthService');
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
