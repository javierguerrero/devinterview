import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, computed, inject, signal } from '@angular/core';
import { Observable, catchError, map, of, throwError } from 'rxjs';
import { environments } from 'src/environments/environments';
import {
  AuthStatus,
  CheckTokenResponse,
  LoginResponse,
  User,
} from '../interfaces';

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

  constructor() {
    this.checkAuthStatus().subscribe();
  }

  private setAuthentication(
    user: User,
    accessToken: string,
    refreshToken: string
  ): boolean {
    this._currentUser.set(user);
    this._authStatus.set(AuthStatus.authenticated);
    localStorage.setItem('accessToken', accessToken);
    localStorage.setItem('refreshToken', refreshToken);

    return true;
  }

  login(username: string, password: string): Observable<boolean> {
    const url = `${this.baseUrl}/api/login`;
    const body = { username: username, password: password };

    return this.http.post<LoginResponse>(url, body).pipe(
      map(({ user, accessToken, refreshToken }) => this.setAuthentication(user, accessToken, refreshToken)),
      catchError((err) => {
        return throwError(() => err.error.title);
      })
    );
  }

  checkAuthStatus(): Observable<boolean> {
    const url = `${this.baseUrl}/api/check-token`;
    const accessToken = localStorage.getItem('accessToken');

    if (!accessToken) {
      this.logout();
      return of(false);
    }

    const headers = new HttpHeaders().set(
      'Authorization',
      `Bearer ${accessToken}`
    );

    return this.http.get<CheckTokenResponse>(url, { headers }).pipe(
      map(({ user, accessToken, refreshToken }) => this.setAuthentication(user, accessToken, refreshToken)),
      catchError(() => {
        this._authStatus.set(AuthStatus.notAuthenticated);
        return of(false);
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
    this._currentUser.set(null);
    this._authStatus.set(AuthStatus.notAuthenticated);
  }
}
