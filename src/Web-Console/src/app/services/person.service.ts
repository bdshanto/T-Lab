import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FileModelVm, PersonVm } from 'src/app/models/PersonVm';
import { environment } from 'src/environments/environment';
import { SkillVm } from 'src/app/models/SkillVm';
import { CountryVm } from 'src/app/models/CountryVm';
import { CityVm } from 'src/app/models/CityVm';

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
    /*     const formData = new FormData();
        // @ts-ignore
        Object.keys(person).forEach(key => {

          if (key === 'resumeFile'){
            // @ts-ignore
            if (person[key]){
              // @ts-ignore
              formData.append(key, person[key]);
            }
          }
          if (key === 'doB'){
            let datestr = (new Date(key)).toUTCString();
              formData.append(key, datestr);
          }
          // @ts-ignore

            // @ts-ignore
            formData.append(key, JSON.stringify(person[key]));

        }); */
    const formData = new FormData();
    Object.keys(person).forEach((key) => {
      //@ts-ignore
      if (Array.isArray(person[key])){
        //@ts-ignore
        person[key].forEach((item,i) => {
          Object.keys(item).forEach((key2) => {
            //@ts-ignore
            formData.append(`${key}[${i}].${key2}`, JSON.stringify(item[key2]));
          });

        });
      }
      else{
        if (key === 'doB'){
          //@ts-ignore
          let datestr = (new Date(person[key])).toUTCString();
          formData.append(key, datestr);
        } else{
          //@ts-ignore
          formData.append(key, person[key]);
        }
      }
    });

    return this.httpClient.post<boolean>(`${this.baseUrl}person`, formData);
  }

  getById(id: number): Observable<PersonVm>{
    return this.httpClient.get <PersonVm>(`${this.baseUrl}person/get-by-id/${id}`);
  }


  delete(id: number): Observable<PersonVm>{
    return this.httpClient.delete<PersonVm>(`${this.baseUrl}person/delete/${id}`);
  }

  getFileById(dto: FileModelVm): Observable<FileModelVm>{
    return this.httpClient.post<FileModelVm>(`${this.baseUrl}person/get-file-by-file-name`, dto);
  }


  public getSkills(): Observable<SkillVm[]>{
    return this.httpClient.get<SkillVm[]>(`${this.baseUrl}Common/get-skill-list`);

  }

  public getCountryList(): Observable<CountryVm[]>{
    return this.httpClient.get<CountryVm[]>(`${this.baseUrl}Common/get-Country-list`);

  }

  public getCityListBycountryId(countryId: number| null): Observable<CityVm[]>{
    return this.httpClient.get<CityVm[]>(`${this.baseUrl}Common/get-city-list-By-country-id/${countryId}`);

  }
}
