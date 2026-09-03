import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { FormField } from '../models/form.models';

const KEY_PATTERN = /^[a-zA-Z][a-zA-Z0-9_]*$/;

export function fieldKeyValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = String(control.value ?? '').trim();
    if (!value) {
      return { required: true };
    }
    return KEY_PATTERN.test(value) ? null : { fieldKey: true };
  };
}

export function createFillFormGroup(fields: FormField[]): FormGroup {
  const group: Record<string, FormControl> = {};
  for (const field of fields) {
    group[field.key] = new FormControl(field.type === 'Checkbox' ? false : '', validatorsFor(field));
  }
  return new FormGroup(group);
}

export function validatorsFor(field: FormField): ValidatorFn[] {
  const validators: ValidatorFn[] = [];
  if (field.required && field.type !== 'Checkbox') {
    validators.push(Validators.required);
  }
  if (field.type === 'Checkbox' && field.required) {
    validators.push(requiredTrue());
  }
  if (field.type === 'Email') {
    validators.push(Validators.email);
  }
  if (field.minLength) {
    validators.push(Validators.minLength(field.minLength));
  }
  if (field.maxLength) {
    validators.push(Validators.maxLength(field.maxLength));
  }
  if (field.type === 'Number') {
    if (field.min != null) {
      validators.push(Validators.min(field.min));
    }
    if (field.max != null) {
      validators.push(Validators.max(field.max));
    }
  }
  if (field.pattern) {
    validators.push(Validators.pattern(field.pattern));
  }
  return validators;
}

function requiredTrue(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null =>
    control.value === true ? null : { required: true };
}

export function nextFieldKey(existing: string[]): string {
  let index = existing.length + 1;
  let key = `field${index}`;
  const used = new Set(existing.map((k) => k.toLowerCase()));
  while (used.has(key.toLowerCase())) {
    index += 1;
    key = `field${index}`;
  }
  return key;
}
