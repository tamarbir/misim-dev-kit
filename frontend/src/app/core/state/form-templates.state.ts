import { inject, Injectable, signal } from '@angular/core';

import { FormTemplatesApi } from '../api/form-templates.api';
import { ApiError } from '../interceptors/api-error.interceptor';
import {
  CreateFormTemplateRequest,
  FormTemplate,
  FormTemplateListItem,
} from '../models/form-template.model';

@Injectable({ providedIn: 'root' })
export class FormTemplatesState {
  private readonly api = inject(FormTemplatesApi);

  readonly templates = signal<FormTemplateListItem[]>([]);
  readonly selected = signal<FormTemplate | null>(null);
  readonly loadingList = signal(false);
  readonly loadingDetails = signal(false);
  readonly saving = signal(false);
  readonly error = signal<string | null>(null);
  readonly success = signal<string | null>(null);

  loadList(): void {
    this.loadingList.set(true);
    this.error.set(null);

    this.api.list().subscribe({
      next: (rows) => {
        this.templates.set(rows);
        this.loadingList.set(false);
      },
      error: (error: ApiError) => {
        this.loadingList.set(false);
        this.error.set(error.messages.join(' '));
      },
    });
  }

  select(id: number): void {
    this.loadingDetails.set(true);
    this.error.set(null);

    this.api.getById(id).subscribe({
      next: (template) => {
        this.selected.set(template);
        this.loadingDetails.set(false);
      },
      error: (error: ApiError) => {
        this.loadingDetails.set(false);
        this.error.set(error.messages.join(' '));
      },
    });
  }

  create(request: CreateFormTemplateRequest, onSaved?: () => void): void {
    this.saving.set(true);
    this.error.set(null);
    this.success.set(null);

    this.api.create(request).subscribe({
      next: (created) => {
        this.saving.set(false);
        this.success.set(`הטופס «${created.name}» נשמר במלואו.`);
        this.selected.set(created);
        this.loadList();
        onSaved?.();
      },
      error: (error: ApiError) => {
        this.saving.set(false);
        this.error.set(error.messages.join(' '));
      },
    });
  }

  clearMessages(): void {
    this.error.set(null);
    this.success.set(null);
  }
}
