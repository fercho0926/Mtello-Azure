import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Login } from 'app/auth/types/login';
import { Sesion } from 'app/auth/types/sesion';
import { User } from 'app/types/user-types-new';
import { UserCreate } from 'app/types/user-create';
import { Company, CreateCompany } from 'app/types/company/create-company';
import { BatchPaycheck } from 'app/types/report/batch-paycheck';

@Injectable({
  providedIn: 'root',
})
export class ReportService {


url = 'https://api-scylla-pdn2.azurewebsites.net/api/';
// url = 'http://localhost:5023/api/';


//   baseUrl: string = environment.ApiUrl + 'login/';
  // baseUrl: string = this.url + 'Login/';
  constructor(private http: HttpClient) {}

  GetAllBatchPayChecks(): Observable<BatchPaycheck[]> {
    return this.http.get<BatchPaycheck[]>(this.url + 'Reporting/GetAllBatchPayChecks/');
  }



}
