import { HttpClient } from '@angular/common/http';
import { Injectable, computed, inject, signal } from '@angular/core';
import { Observable, map, of, retry, tap } from 'rxjs';
import { environments } from 'src/environments/environments';
import { AuthStatus, LoginResponse, User } from '../interfaces';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly baseUrl: string = environments.baseUrl;
  private http = inject(HttpClient);

  private _currentUser = signal<User | null>(null);
  private _authStatus = signal<AuthStatus>(AuthStatus.checking);

  public currentUser = computed(() => this._currentUser());
  public authStatus = computed(() => this._authStatus());

  constructor() {}

  login(username: string, password: string): Observable<boolean> {
    debugger;
    const url = `${this.baseUrl}/api/login`;
    const body = { username: username, password: password };

    return this.http.post<LoginResponse>(url, body).pipe(
      tap(({ user, token }) => {
        this._currentUser.set(user);
        this._authStatus.set(AuthStatus.authenticated);
        localStorage.setItem('token', token);

        console.log({ user, token });
      }),
      map(() => true)
    );

    //todo: errores
  }
}
