import { DatePipe } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { FormField, SubmissionDetail } from '../../core/models/form.models';
import { FormsApiService } from '../../core/services/forms-api.service';

@Component({
  selector: 'app-submission-detail',
  imports: [RouterLink, DatePipe],
  templateUrl: './submission-detail.html',
  styleUrl: './submission-detail.scss',
})
export class SubmissionDetailPage {
  private readonly api = inject(FormsApiService);
  private readonly route = inject(ActivatedRoute);

  readonly submission = signal<SubmissionDetail | null>(null);
  readonly error = signal<string | null>(null);

  constructor() {
    const id = this.route.snapshot.paramMap.get('id')!;
    this.api.getSubmission(id).subscribe({
      next: (item) => this.submission.set(item),
      error: (err: Error) => this.error.set(err.message),
    });
  }

  displayValue(field: FormField): string {
    const value = this.submission()?.values?.[field.key];
    if (value == null || value === '') {
      return '—';
    }
    if (typeof value === 'boolean') {
      return value ? 'כן' : 'לא';
    }
    return String(value);
  }
}
