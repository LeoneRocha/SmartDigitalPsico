import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';  
import { ServiceResponse } from 'app/models/ServiceResponse';
import { environment } from 'environments/environment'; 
import { GenericService } from 'app/services/generic/generic.service';  
import { UserModel } from 'app/models/PrincipalsModel/UserModel';

const basePathUrl = '/User/v1';
@Injectable()
export class UserService extends GenericService<ServiceResponse<UserModel>, UserModel, number> {

  constructor(@Inject(HttpClient) http: HttpClient) {
    super(http, `${environment.APIUrl + basePathUrl}`, '/FindAll');
  }

}
