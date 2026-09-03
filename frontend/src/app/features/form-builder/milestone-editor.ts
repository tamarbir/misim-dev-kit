import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { FormArray, ReactiveFormsModule } from '@angular/forms';

import { ACTION_TYPE_LABEL, ApprovalActionType } from '../../core/models/form-template.model';
import { StepGroup } from './form-builder.types';

@Component({
  selector: 'app-milestone-editor',
  imports: [ReactiveFormsModule],
  templateUrl: './milestone-editor.html',
  styleUrl: './milestone-editor.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MilestoneEditor {
  readonly steps = input.required<FormArray<StepGroup>>();
  readonly add = output<void>();
  readonly remove = output<number>();

  protected readonly actions: ApprovalActionType[] = ['Approve', 'Reject', 'ApproveOrReject'];
  protected readonly actionLabel = ACTION_TYPE_LABEL;
}
