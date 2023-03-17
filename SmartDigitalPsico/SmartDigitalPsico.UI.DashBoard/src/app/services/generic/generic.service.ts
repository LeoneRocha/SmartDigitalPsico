import { HttpClient } from '@angular/common/http';
import { GenericServiceModel } from 'app/models/GenericServiceModel';
import { Observable } from 'rxjs';
import { Inject } from '@angular/core';


export class GenericService<T, E, ID> implements GenericServiceModel<T, E, ID> {
  constructor(@Inject(HttpClient) private http: HttpClient, private baseUrl: string, private urlgetAll: string) { }

  add(t: E): Observable<any> {
    return this.http.post<T>(this.baseUrl, t);
  }

  update(t: E): Observable<T> {
    return this.http.put<T>(`${this.baseUrl}/`, t);
  }

  getById(id: ID): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}/${id}`);
  }

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.baseUrl + this.urlgetAll);
  }

  delete(id: ID): Observable<any> {
    return this.http.delete<T>(`${this.baseUrl}/${id}`);
  }
}
