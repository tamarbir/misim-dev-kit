import { DatePipe } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { FormDetail, SubmissionSummary } from '../../core/models/form.models';
import { FormsApiService } from '../../core/services/forms-api.service';

@Component({
  selector: 'app-submission-list',
  imports: [RouterLink, DatePipe],
  templateUrl: './submission-list.html',
  styleUrl: './submission-list.scss',
})
export class SubmissionList {
  private readonly api = inject(FormsApiService);
  private readonly route = inject(ActivatedRoute);

  readonly form = signal<FormDetail | null>(null);
  readonly submissions = signal<SubmissionSummary[]>([]);
  readonly error = signal<string | null>(null);

  constructor() {
    const id = this.route.snapshot.paramMap.get('id')!;
    this.api.getForm(id).subscribe({
      next: (form) => {
        this.form.set(form);
        this.api.listSubmissions(id).subscribe({
          next: (items) => this.submissions.set(items),
          error: (err: Error) => this.error.set(err.message),
        });
      },
      error: (err: Error) => this.error.set(err.message),
    });
  }
}
