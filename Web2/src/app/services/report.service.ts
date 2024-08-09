import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
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
