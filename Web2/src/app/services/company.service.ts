import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Login } from 'app/auth/types/login';
import { Sesion } from 'app/auth/types/sesion';
import { User } from 'app/types/user-types-new';
import { UserCreate } from 'app/types/user-create';
import { Company, CreateCompany } from 'app/types/company/create-company';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {


// url = 'https://api-scylla-pdn2.azurewebsites.net/api/';
url = 'http://localhost:5023/api/';


//   baseUrl: string = environment.ApiUrl + 'login/';
  // baseUrl: string = this.url + 'Login/';
  constructor(private http: HttpClient) {}

  getAll(): Observable<Company[]> {
    return this.http.get<Company[]>(this.url + 'Company/');
  }

  create(request: CreateCompany): Observable<CreateCompany> {
    return this.http.post<CreateCompany>(`${this.url}/Company/Create`, request);
  }

}
