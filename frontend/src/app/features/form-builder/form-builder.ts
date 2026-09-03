import { ChangeDetectionStrategy, Component, inject, OnInit } from '@angular/core';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

import { FormTemplatesState } from '../../core/state/form-templates.state';
import { ApprovalActionType, FieldType } from '../../core/models/form-template.model';
import { FieldEditor } from './field-editor';
import { FieldGroup, StepGroup, TemplateForm } from './form-builder.types';
import { MilestoneEditor } from './milestone-editor';
import { TemplateList } from './template-list';

@Component({
  selector: 'app-form-builder',
  imports: [ReactiveFormsModule, FieldEditor, MilestoneEditor, TemplateList],
  templateUrl: './form-builder.html',
  styleUrl: './form-builder.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FormBuilderPage implements OnInit {
  private readonly fb = inject(NonNullableFormBuilder);
  protected readonly state = inject(FormTemplatesState);

  protected readonly form: TemplateForm = this.fb.group({
    name: this.fb.control('', Validators.required),
    createdBy: this.fb.control(''),
    fields: this.fb.array<FieldGroup>([]),
    steps: this.fb.array<StepGroup>([]),
  });

  ngOnInit(): void {
    this.state.loadList();
  }

  protected addField(fieldType: FieldType): void {
    this.form.controls.fields.push(
      this.fb.group({
        label: this.fb.control('', Validators.required),
        fieldType: this.fb.control<FieldType>(fieldType),
        isRequired: this.fb.control(false),
      }),
    );
  }

  protected removeField(index: number): void {
    this.form.controls.fields.removeAt(index);
  }

  protected addStep(): void {
    this.form.controls.steps.push(
      this.fb.group({
        name: this.fb.control('', Validators.required),
        approverIdentity: this.fb.control('', Validators.required),
        actionType: this.fb.control<ApprovalActionType>('ApproveOrReject'),
      }),
    );
  }

  protected removeStep(index: number): void {
    this.form.controls.steps.removeAt(index);
  }

  protected save(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      this.state.error.set('יש למלא את שדות החובה בטופס לפני השמירה.');
      return;
    }

    const value = this.form.getRawValue();
    this.state.create(
      {
        name: value.name,
        createdBy: value.createdBy || undefined,
        fields: value.fields,
        steps: value.steps,
      },
      () => this.resetForm(),
    );
  }

  private resetForm(): void {
    this.form.reset({ name: '', createdBy: '' });
    this.form.controls.fields.clear();
    this.form.controls.steps.clear();
  }
}
