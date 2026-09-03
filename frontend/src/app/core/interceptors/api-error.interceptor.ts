import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

export interface ApiError {
  status: number;
  messages: string[];
}

export const apiErrorInterceptor: HttpInterceptorFn = (req, next) =>
  next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      const payload = error.error as { errors?: unknown } | null;
      const messages = Array.isArray(payload?.errors)
        ? payload.errors.filter((item): item is string => typeof item === 'string')
        : [];

      const apiError: ApiError = {
        status: error.status,
        messages: messages.length > 0 ? messages : ['לא ניתן להשלים את הפעולה מול השרת.'],
      };

      return throwError(() => apiError);
    }),
  );
