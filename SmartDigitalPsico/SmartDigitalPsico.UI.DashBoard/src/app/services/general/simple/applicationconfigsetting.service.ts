import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core'; 

import { ServiceResponse } from 'app/models/ServiceResponse';
import { environment } from 'environments/environment';
import { ApplicationConfigSettingModel } from 'app/models/SimpleModel/ApplicationConfigSettingModel';
import { GenericService } from 'app/services/generic/generic.service';

const basePathUrl = '/ApplicationConfigSetting/v1';
@Injectable()
export class ApplicationConfigSettingService extends GenericService<ServiceResponse<ApplicationConfigSettingModel>, ApplicationConfigSettingModel, number> {

  constructor(@Inject(HttpClient) http: HttpClient) {
    super(http, `${environment.APIUrl + basePathUrl}`, '/FindAll');
  }

}