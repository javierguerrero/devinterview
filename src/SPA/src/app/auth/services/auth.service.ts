import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import { environments } from 'src/environments/environments';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly baseUrl: string = environments.baseUrl;
  private http = inject(HttpClient);

  //private _currentUser = signal<User | null>(null);
  //private _authStatus = signal<AuthStatus>();

  constructor() {}

  login(username: string, password: string): Observable<boolean> {
    return of(true);
  }
}
