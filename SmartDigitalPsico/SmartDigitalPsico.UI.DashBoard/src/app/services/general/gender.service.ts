import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { map, Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Inject } from '@angular/core';
import { GenderModel, ServiceResponse } from 'app/models/GenderModel';
import { GenericService } from '../generic/generic.service';

const baseUrl = 'https://localhost:61949/api/Gender/v1';
/*
@Injectable()
export class GenderService {

  private url: string;

  constructor(@Inject(HttpClient) private http: HttpClient) {

   } 

  getAll() {

    this.url = `${baseUrl}/GetAll`;
    return this.http.get(this.url).pipe(map(response => response['data'])); 
  } 
} */
@Injectable()
export class GenderService extends GenericService<ServiceResponse<GenderModel>, number> {

  constructor(@Inject(HttpClient) http: HttpClient) {
    super(http, `${'https://localhost:61949/api/Gender/v1'}`, '/GetAll');
  }

}
