import { HttpClient, HttpHeaders, } from '@angular/common/http';
import { GenericServiceModel } from 'app/models/GenericServiceModel';
import { catchError, map, Observable, throwError } from 'rxjs';
import { Inject } from '@angular/core';
import { BadInput } from 'app/common/bad-input';
import { NotFoundError } from 'app/common/not-found-error';
import { AppError } from 'app/common/app-error';
import { CaptureTologFunc } from 'app/common/app-error-handler';


export class GenericService<T, E, ID> implements GenericServiceModel<T, E, ID> {
   

  protected httpLocal: HttpClient;
  constructor(@Inject(HttpClient) private http: HttpClient, private baseUrl: string, private urlgetAll: string) {
    this.httpLocal = http;
  }

  add(t: E): Observable<any> {
    return this.http.post<T>(this.baseUrl, t).pipe(map(response => { response; CaptureTologFunc('GenericService-add', response); }), catchError(this.customHandleError));
  }

  update(t: E): Observable<T> {
    return this.http.put<T>(`${this.baseUrl}/`, t).pipe(map(response => response), catchError(this.customHandleError));
  }

  getById(id: ID): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}/${id}`).pipe(map(response => response), catchError(this.customHandleError));
  }

  getAll(): Observable<T[]> {

    let token = localStorage.getItem('tokenjwt');
    const headers = new HttpHeaders()
      .set('Authorization', `Bearer ${token}`);

    return this.http.get<T[]>(this.baseUrl + this.urlgetAll, { headers: headers }).pipe(map(response => response), catchError(this.customHandleError));
  }

  delete(id: ID): Observable<any> {
    return this.http.delete<T>(`${this.baseUrl}/${id}`).pipe(map(response => response), catchError(this.customHandleError));
  }



  private customHandleError(error: Response) {
    console.log('customHandleError');
    if (error.status === 400)
      return throwError(() => new BadInput(error.json()));

    if (error.status === 404)
      return throwError(() => new NotFoundError());

    //return Observable.throw(new AppError(error));
    // Return an observable with a user-facing error message.
    return throwError(() => new AppError(error));
  }


}
