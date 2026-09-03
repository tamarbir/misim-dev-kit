import { DatePipe } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FormSummary } from '../../core/models/form.models';
import { FormsApiService } from '../../core/services/forms-api.service';

@Component({
  selector: 'app-form-list',
  imports: [RouterLink, DatePipe],
  templateUrl: './form-list.html',
  styleUrl: './form-list.scss',
})
export class FormList {
  private readonly api = inject(FormsApiService);

  readonly forms = signal<FormSummary[]>([]);
  readonly loading = signal(true);
  readonly error = signal<string | null>(null);

  constructor() {
    this.reload();
  }

  reload(): void {
    this.loading.set(true);
    this.api.listForms().subscribe({
      next: (forms) => {
        this.forms.set(forms);
        this.loading.set(false);
        this.error.set(null);
      },
      error: (err: Error) => {
        this.error.set(err.message);
        this.loading.set(false);
      },
    });
  }

  remove(form: FormSummary): void {
    if (!confirm(`למחוק את הטופס "${form.name}"?`)) {
      return;
    }

    this.api.deleteForm(form.id).subscribe({
      next: () => this.reload(),
      error: (err: Error) => this.error.set(err.message),
    });
  }
}
