import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Sesion } from 'app/auth/types/sesion';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  constructor(private _snackBar: MatSnackBar) {}

  showAlert(message: string, type: string) {
    this._snackBar.open(message, type, {
      horizontalPosition: 'end',
      verticalPosition: 'top',
      duration: 5000,
    });
  }

  saveSession(session: Sesion) {
    localStorage.setItem('userSession', JSON.stringify(session));
  }

  getSession(): Sesion {
    const sesionString = localStorage.getItem('userSession');
    const userToken = JSON.parse(sesionString!);

    return userToken;
  }

  deleteSession() {
    localStorage.removeItem('userSession');
  }
}
