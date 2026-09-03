import { Component, inject, signal } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { FormDetail, FormField } from '../../core/models/form.models';
import { FormsApiService } from '../../core/services/forms-api.service';
import { createFillFormGroup } from '../../core/utils/form.utils';

@Component({
  selector: 'app-form-fill',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './form-fill.html',
  styleUrl: './form-fill.scss',
})
export class FormFill {
  private readonly api = inject(FormsApiService);
  private readonly route = inject(ActivatedRoute);

  readonly form = signal<FormDetail | null>(null);
  readonly fillForm = signal<FormGroup | null>(null);
  readonly submitterName = signal('');
  readonly error = signal<string | null>(null);
  readonly success = signal<string | null>(null);
  readonly submitting = signal(false);

  constructor() {
    const id = this.route.snapshot.paramMap.get('id')!;
    this.api.getForm(id).subscribe({
      next: (form) => {
        this.form.set(form);
        this.fillForm.set(createFillFormGroup(form.fields));
      },
      error: (err: Error) => this.error.set(err.message),
    });
  }

  fields(): FormField[] {
    return this.form()?.fields ?? [];
  }

  control(key: string) {
    return this.fillForm()?.get(key);
  }

  submit(): void {
    const form = this.form();
    const group = this.fillForm();
    if (!form || !group) {
      return;
    }

    group.markAllAsTouched();
    if (group.invalid) {
      this.error.set('יש לתקן את שגיאות הטופס לפני ההגשה.');
      return;
    }

    this.submitting.set(true);
    this.error.set(null);
    this.api.submitForm(form.id, this.submitterName(), group.getRawValue()).subscribe({
      next: () => {
        this.submitting.set(false);
        this.success.set('ההגשה נקלטה בהצלחה.');
        group.reset();
      },
      error: (err: Error) => {
        this.submitting.set(false);
        this.error.set(err.message);
      },
    });
  }
}
