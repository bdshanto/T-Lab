import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FileModelVm, PersonVm } from 'src/app/models/PersonVm';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private readonly baseUrl = environment.baseUrl;

  constructor(private httpClient: HttpClient){
  }

  get(): Observable<PersonVm[]>{
    return this.httpClient.get <PersonVm []>(`${this.baseUrl}person`);
  }

  post(person: PersonVm): Observable<boolean>{
    return this.httpClient.post<boolean>(`${this.baseUrl}person`, person);
  }

  getById(id: number): Observable<PersonVm>{
    return this.httpClient.get <PersonVm>(`${this.baseUrl}person/${id}`);
  }


  delete(id: number): Observable<PersonVm>{
    return this.httpClient.delete<PersonVm>(`${this.baseUrl}person/${id}`);
  }

  getFileById(dto: FileModelVm): Observable<FileModelVm>{
    return this.httpClient.post<FileModelVm>(`${this.baseUrl}person/get-file-by-file-name`, dto);
  }


}
