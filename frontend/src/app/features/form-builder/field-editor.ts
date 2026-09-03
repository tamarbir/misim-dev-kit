import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { FormArray, ReactiveFormsModule } from '@angular/forms';

import { FIELD_TYPE_LABEL } from '../../core/models/form-template.model';
import { FieldGroup } from './form-builder.types';

@Component({
  selector: 'app-field-editor',
  imports: [ReactiveFormsModule],
  templateUrl: './field-editor.html',
  styleUrl: './field-editor.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FieldEditor {
  readonly fields = input.required<FormArray<FieldGroup>>();
  readonly addText = output<void>();
  readonly addDate = output<void>();
  readonly remove = output<number>();

  protected readonly typeLabel = FIELD_TYPE_LABEL;
}
