import { DatePipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';

import {
  ACTION_TYPE_LABEL,
  FIELD_TYPE_LABEL,
  FormTemplate,
  FormTemplateListItem,
} from '../../core/models/form-template.model';

@Component({
  selector: 'app-template-list',
  imports: [DatePipe],
  templateUrl: './template-list.html',
  styleUrl: './template-list.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TemplateList {
  readonly templates = input.required<FormTemplateListItem[]>();
  readonly selected = input<FormTemplate | null>(null);
  readonly loadingList = input(false);
  readonly loadingDetails = input(false);
  readonly selectId = output<number>();

  protected readonly fieldLabel = FIELD_TYPE_LABEL;
  protected readonly actionLabel = ACTION_TYPE_LABEL;
}
