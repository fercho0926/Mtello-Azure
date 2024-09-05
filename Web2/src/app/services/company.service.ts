import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Company, CreateCompany } from 'app/types/company/create-company';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {


  baseUrl: string = environment.api_Url;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Company[]> {
    return this.http.get<Company[]>(this.baseUrl + 'Company/');
  }

  create(request: CreateCompany): Observable<CreateCompany> {
    return this.http.post<CreateCompany>(`${this.baseUrl}/Company/Create`, request);
  }

}
