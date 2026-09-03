import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import {
  CreateFormTemplateRequest,
  FormTemplate,
  FormTemplateListItem,
} from '../models/form-template.model';

@Injectable({ providedIn: 'root' })
export class FormTemplatesApi {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = '/api/form-templates';

  list(): Observable<FormTemplateListItem[]> {
    return this.http.get<FormTemplateListItem[]>(this.baseUrl);
  }

  getById(id: number): Observable<FormTemplate> {
    return this.http.get<FormTemplate>(`${this.baseUrl}/${id}`);
  }

  create(body: CreateFormTemplateRequest): Observable<FormTemplate> {
    return this.http.post<FormTemplate>(this.baseUrl, body);
  }
}
