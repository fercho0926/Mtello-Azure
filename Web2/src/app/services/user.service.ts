import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Login } from 'app/auth/types/login';
import { Sesion } from 'app/auth/types/sesion';
import { User } from 'app/types/user-types-new';
import { UserCreate } from 'app/types/user-create';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  baseUrl: string = environment.api_Url;

// url = 'https://api-scylla-pdn2.azurewebsites.net/api/';
// url = 'https://api-scylla-pdn2.azurewebsites.net/api/';

//   baseUrl: string = environment.ApiUrl + 'login/';
  // baseUrl: string = this.url + 'Login/';
  constructor(private http: HttpClient) {}

  sigIn(request: Login): Observable<Sesion> {
    
    return this.http.post<Sesion>(this.baseUrl + 'Login/', request);
  }


  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'User/');
  }

  createUser(user: UserCreate): Observable<UserCreate> {
    return this.http.post<UserCreate>(`${this.baseUrl}/Users/Create`, user);
  }

}
