import { FormArray, FormControl, FormGroup } from '@angular/forms';

import { ApprovalActionType, FieldType } from '../../core/models/form-template.model';

export interface FieldControls {
  label: FormControl<string>;
  fieldType: FormControl<FieldType>;
  isRequired: FormControl<boolean>;
}

export interface StepControls {
  name: FormControl<string>;
  approverIdentity: FormControl<string>;
  actionType: FormControl<ApprovalActionType>;
}

export interface TemplateControls {
  name: FormControl<string>;
  createdBy: FormControl<string>;
  fields: FormArray<FormGroup<FieldControls>>;
  steps: FormArray<FormGroup<StepControls>>;
}

export type FieldGroup = FormGroup<FieldControls>;
export type StepGroup = FormGroup<StepControls>;
export type TemplateForm = FormGroup<TemplateControls>;
