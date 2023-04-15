import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';  
import { ServiceResponse } from 'app/models/ServiceResponse';
import { environment } from 'environments/environment'; 
import { GenericService } from 'app/services/generic/generic.service';    
import { PatientNotificationMessageModel } from 'app/models/principalsmodel/PatientNotificationMessageModel';

//localhost:61949/api/patient/v1/PatientAdditionalInformation/FindAll?patientId=1
const basePathUrl = '/patient/v1/PatientNotificationMessage';
@Injectable()
export class PatientNotificationMessageService extends GenericService<ServiceResponse<PatientNotificationMessageModel>, PatientNotificationMessageModel, number> {

  constructor(@Inject(HttpClient) http: HttpClient) {
    super(http, `${environment.APIUrl + basePathUrl}`, '/FindAll');
  }

}
