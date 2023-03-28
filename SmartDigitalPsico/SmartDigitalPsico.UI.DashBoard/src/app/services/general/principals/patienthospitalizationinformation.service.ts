import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';  
import { ServiceResponse } from 'app/models/ServiceResponse';
import { environment } from 'environments/environment'; 
import { GenericService } from 'app/services/generic/generic.service';   
import { PatientHospitalizationInformationModel } from 'app/models/PrincipalsModel/PatientHospitalizationInformationModel';

const basePathUrl = '/PatientHospitalizationInformation/v1';
@Injectable()
export class PatientHospitalizationInformationService extends GenericService<ServiceResponse<PatientHospitalizationInformationModel>, PatientHospitalizationInformationModel, number> {

  constructor(@Inject(HttpClient) http: HttpClient) {
    super(http, `${environment.APIUrl + basePathUrl}`, '/FindAll');
  }

}
