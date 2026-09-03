import { CdkDragDrop, DragDropModule, moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, computed, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FIELD_TYPES, FieldType, FormField } from '../../core/models/form.models';
import { FormsApiService } from '../../core/services/forms-api.service';
import { fieldKeyValidator, nextFieldKey } from '../../core/utils/form.utils';

@Component({
  selector: 'app-form-builder',
  imports: [ReactiveFormsModule, RouterLink, DragDropModule],
  templateUrl: './form-builder.html',
  styleUrl: './form-builder.scss',
})
export class FormBuilderPage {
  private readonly api = inject(FormsApiService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly fb = inject(FormBuilder);

  readonly fieldTypes = FIELD_TYPES;
  readonly formId = signal<string | null>(this.route.snapshot.paramMap.get('id'));
  readonly status = signal<'Draft' | 'Published'>('Draft');
  readonly fields = signal<FormField[]>([]);
  readonly selectedIndex = signal(0);
  readonly saving = signal(false);
  readonly message = signal<string | null>(null);
  readonly error = signal<string | null>(null);

  readonly meta = this.fb.nonNullable.group({
    name: ['', [Validators.required, Validators.maxLength(200)]],
    description: [''],
  });

  readonly fieldForm = this.fb.nonNullable.group({
    key: ['', [Validators.required, fieldKeyValidator()]],
    label: ['', Validators.required],
    type: this.fb.nonNullable.control<FieldType>('Text'),
    required: [false],
    placeholder: [''],
    helpText: [''],
    optionsText: [''],
    min: this.fb.control<number | null>(null),
    max: this.fb.control<number | null>(null),
    minLength: this.fb.control<number | null>(null),
    maxLength: this.fb.control<number | null>(null),
    pattern: [''],
  });

  readonly selectedField = computed(() => this.fields()[this.selectedIndex()] ?? null);
  readonly isNew = computed(() => !this.formId());
  readonly needsOptions = computed(() => {
    const type = this.fieldForm.controls.type.value;
    return type === 'Select' || type === 'Radio';
  });

  constructor() {
    const id = this.formId();
    if (id) {
      this.api.getForm(id).subscribe({
        next: (form) => {
          this.meta.patchValue({ name: form.name, description: form.description });
          this.status.set(form.status);
          this.fields.set(form.fields);
          if (form.fields[0]) {
            this.selectField(0);
          }
        },
        error: (err: Error) => this.error.set(err.message),
      });
    }

    this.fieldForm.valueChanges.subscribe(() => this.persistSelectedField());
  }

  addField(type: FieldType): void {
    this.persistSelectedField();
    const field: FormField = {
      key: nextFieldKey(this.fields().map((f) => f.key)),
      label: FIELD_TYPES.find((item) => item.type === type)?.label ?? 'שדה חדש',
      type,
      required: false,
      sortOrder: this.fields().length,
      options: type === 'Select' || type === 'Radio' ? ['אפשרות 1', 'אפשרות 2'] : [],
    };
    this.fields.update((list) => [...list, field]);
    this.selectField(this.fields().length - 1, false);
  }

  selectField(index: number, persist = true): void {
    if (persist) {
      this.persistSelectedField();
    }
    this.selectedIndex.set(index);
    const field = this.fields()[index];
    if (!field) {
      return;
    }

    this.fieldForm.reset(
      {
        key: field.key,
        label: field.label,
        type: field.type,
        required: field.required,
        placeholder: field.placeholder ?? '',
        helpText: field.helpText ?? '',
        optionsText: (field.options ?? []).join('\n'),
        min: field.min ?? null,
        max: field.max ?? null,
        minLength: field.minLength ?? null,
        maxLength: field.maxLength ?? null,
        pattern: field.pattern ?? '',
      },
      { emitEvent: false },
    );
  }

  removeSelected(): void {
    const index = this.selectedIndex();
    this.fields.update((list) => list.filter((_, i) => i !== index));
    this.selectField(Math.max(0, index - 1));
  }

  drop(event: CdkDragDrop<FormField[]>): void {
    const copy = [...this.fields()];
    moveItemInArray(copy, event.previousIndex, event.currentIndex);
    this.fields.set(copy.map((field, index) => ({ ...field, sortOrder: index })));
    this.selectedIndex.set(event.currentIndex);
  }

  save(publish = false): void {
    this.persistSelectedField();
    this.meta.markAllAsTouched();
    if (this.meta.invalid) {
      this.error.set('יש להזין שם לטופס.');
      return;
    }
    if (this.fields().length === 0) {
      this.error.set('יש להוסיף לפחות שדה אחד.');
      return;
    }

    this.saving.set(true);
    this.error.set(null);
    const request = {
      name: this.meta.controls.name.value,
      description: this.meta.controls.description.value,
      fields: this.fields().map((field, index) => ({ ...field, sortOrder: index })),
    };

    const request$ = this.formId()
      ? this.api.updateForm(this.formId()!, request)
      : this.api.createForm(request);

    request$.subscribe({
      next: (form) => {
        this.formId.set(form.id);
        this.status.set(form.status);
        this.fields.set(form.fields);
        if (publish) {
          this.api.publishForm(form.id).subscribe({
            next: (published) => {
              this.status.set(published.status);
              this.saving.set(false);
              this.message.set('הטופס נשמר ופורסם.');
              void this.router.navigate(['/forms', form.id, 'edit']);
            },
            error: (err: Error) => {
              this.saving.set(false);
              this.error.set(err.message);
            },
          });
          return;
        }
        this.saving.set(false);
        this.message.set('הטופס נשמר.');
        void this.router.navigate(['/forms', form.id, 'edit']);
      },
      error: (err: Error) => {
        this.saving.set(false);
        this.error.set(err.message);
      },
    });
  }

  unpublish(): void {
    const id = this.formId();
    if (!id) {
      return;
    }
    this.api.unpublishForm(id).subscribe({
      next: (form) => {
        this.status.set(form.status);
        this.message.set('הטופס הוחזר לטיוטה.');
      },
      error: (err: Error) => this.error.set(err.message),
    });
  }

  private persistSelectedField(): void {
    const index = this.selectedIndex();
    const current = this.fields()[index];
    if (!current) {
      return;
    }

    const value = this.fieldForm.getRawValue();
    const options = value.optionsText
      .split('\n')
      .map((line) => line.trim())
      .filter(Boolean);

    const updated: FormField = {
      ...current,
      key: value.key.trim(),
      label: value.label.trim(),
      type: value.type,
      required: value.required,
      placeholder: value.placeholder || null,
      helpText: value.helpText || null,
      options: value.type === 'Select' || value.type === 'Radio' ? options : [],
      min: value.min,
      max: value.max,
      minLength: value.minLength,
      maxLength: value.maxLength,
      pattern: value.pattern || null,
    };

    this.fields.update((list) => list.map((field, i) => (i === index ? updated : field)));
  }
}
