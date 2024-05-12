import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { AuthService } from 'src/app/auth/services/auth.service';

export const tokenInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const accessToken = localStorage.getItem('accessToken');

  const cloneRequest = req.clone({
    setHeaders: {
      Authorization: `Bearer ${accessToken}`,
    },
  });

  return next(cloneRequest).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error.status === 401) {
        const isRefresh = confirm(
          'Your session is expired. Do you wnat to continue?'
        );
        if (isRefresh) {
          authService.refreshToken.next(true);
        }
      }
      return throwError(error);
    })
  );
};
