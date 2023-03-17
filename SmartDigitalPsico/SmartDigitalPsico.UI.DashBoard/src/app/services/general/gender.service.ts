import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { GenderModel } from 'app/models/GenderModel';
import { GenericService } from '../generic/generic.service';
import { ServiceResponse } from 'app/models/ServiceResponse';

const baseUrl = 'https://localhost:61949/api/Gender/v1';

@Injectable()
export class GenderService extends GenericService<ServiceResponse<GenderModel>, GenderModel, number> {

  constructor(@Inject(HttpClient) http: HttpClient) {
    super(http, `${'https://localhost:61949/api/Gender/v1'}`, '/GetAll');
  }

}
