import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, computed, inject, signal } from '@angular/core';
import { Observable, Subject, catchError, map, of, throwError } from 'rxjs';
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

  public refreshToken = new Subject<boolean>();
  public refreshTokenRecieved = new Subject<boolean>();

  constructor() {
    this.getRefreshToken().subscribe();

    this.refreshToken.subscribe((res: any) => {
      this.getRefreshToken();
    });
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
      map(({ user, accessToken, refreshToken }) =>
        this.setAuthentication(user, accessToken, refreshToken)
      ),
      catchError((err) => {
        return throwError(() => err.error.title);
      })
    );
  }

  getRefreshToken(): Observable<boolean> {
    const url = `${this.baseUrl}/api/refresh`;
    const refreshToken = localStorage.getItem('refreshToken');
    const body = { accessToken: '', refreshToken: refreshToken };

    if (!refreshToken) {
      this.logout();
      return of(false);
    }

    return this.http.post<LoginResponse>(url, body).pipe(
      map(({ user, accessToken, refreshToken }) =>
        this.setAuthentication(user, accessToken, refreshToken)
      ),
      catchError(() => {
        this._authStatus.set(AuthStatus.notAuthenticated);
        return of(false);
      })
    );
  }

  logout() {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');

    this._currentUser.set(null);
    this._authStatus.set(AuthStatus.notAuthenticated);
  }
}
