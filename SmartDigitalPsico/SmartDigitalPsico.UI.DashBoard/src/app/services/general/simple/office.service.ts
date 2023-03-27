import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';  
import { ServiceResponse } from 'app/models/ServiceResponse';
import { environment } from 'environments/environment';
import { OfficeModel } from 'app/models/SimpleModel/OfficeModel';
import { RoleGroupModel } from 'app/models/SimpleModel/RoleGroupModel';
import { GenericService } from 'app/services/generic/generic.service';

const basePathUrl = '/Office/v1';
@Injectable()
export class OfficeService extends GenericService<ServiceResponse<RoleGroupModel>, OfficeModel, number> {

  constructor(@Inject(HttpClient) http: HttpClient) {
    super(http, `${environment.APIUrl + basePathUrl}`, '/FindAll');
  }

}
