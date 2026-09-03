import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import {
  ApiErrorBody,
  FormDetail,
  FormSummary,
  SubmissionDetail,
  SubmissionSummary,
  UpsertFormRequest,
} from '../models/form.models';

@Injectable({ providedIn: 'root' })
export class FormsApiService {
  private readonly http = inject(HttpClient);
  private readonly base = '/api';

  listForms(): Observable<FormSummary[]> {
    return this.http.get<FormSummary[]>(`${this.base}/forms`).pipe(catchError(this.rethrow));
  }

  getForm(id: string): Observable<FormDetail> {
    return this.http.get<FormDetail>(`${this.base}/forms/${id}`).pipe(catchError(this.rethrow));
  }

  createForm(request: UpsertFormRequest): Observable<FormDetail> {
    return this.http.post<FormDetail>(`${this.base}/forms`, request).pipe(catchError(this.rethrow));
  }

  updateForm(id: string, request: UpsertFormRequest): Observable<FormDetail> {
    return this.http.put<FormDetail>(`${this.base}/forms/${id}`, request).pipe(catchError(this.rethrow));
  }

  deleteForm(id: string): Observable<void> {
    return this.http.delete<void>(`${this.base}/forms/${id}`).pipe(catchError(this.rethrow));
  }

  publishForm(id: string): Observable<FormDetail> {
    return this.http.post<FormDetail>(`${this.base}/forms/${id}/publish`, {}).pipe(catchError(this.rethrow));
  }

  unpublishForm(id: string): Observable<FormDetail> {
    return this.http.post<FormDetail>(`${this.base}/forms/${id}/unpublish`, {}).pipe(catchError(this.rethrow));
  }

  submitForm(id: string, submitterName: string, values: Record<string, unknown>): Observable<SubmissionDetail> {
    return this.http
      .post<SubmissionDetail>(`${this.base}/forms/${id}/submissions`, { submitterName, values })
      .pipe(catchError(this.rethrow));
  }

  listSubmissions(formId: string): Observable<SubmissionSummary[]> {
    return this.http
      .get<SubmissionSummary[]>(`${this.base}/forms/${formId}/submissions`)
      .pipe(catchError(this.rethrow));
  }

  getSubmission(id: string): Observable<SubmissionDetail> {
    return this.http.get<SubmissionDetail>(`${this.base}/submissions/${id}`).pipe(catchError(this.rethrow));
  }

  private rethrow = (error: HttpErrorResponse) => {
    const body = error.error as ApiErrorBody | undefined;
    const message = body?.errors?.join('\n') || error.message || 'אירעה שגיאה בשרת.';
    return throwError(() => new Error(message));
  };
}
