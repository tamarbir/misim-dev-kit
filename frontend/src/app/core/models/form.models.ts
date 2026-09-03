export type FieldType =
  | 'Text'
  | 'TextArea'
  | 'Number'
  | 'Date'
  | 'Select'
  | 'Checkbox'
  | 'Radio'
  | 'Email';

export type FormStatus = 'Draft' | 'Published';

export interface FormField {
  id?: string;
  key: string;
  label: string;
  type: FieldType;
  required: boolean;
  placeholder?: string | null;
  helpText?: string | null;
  sortOrder: number;
  options?: string[] | null;
  min?: number | null;
  max?: number | null;
  minLength?: number | null;
  maxLength?: number | null;
  pattern?: string | null;
}

export interface FormSummary {
  id: string;
  name: string;
  description: string;
  status: FormStatus;
  fieldCount: number;
  submissionCount: number;
  updatedAt: string;
}

export interface FormDetail {
  id: string;
  name: string;
  description: string;
  status: FormStatus;
  fields: FormField[];
  createdAt: string;
  updatedAt: string;
}

export interface UpsertFormRequest {
  name: string;
  description: string;
  fields: FormField[];
}

export interface SubmitFormRequest {
  submitterName?: string | null;
  values: Record<string, unknown>;
}

export interface SubmissionSummary {
  id: string;
  formId: string;
  formName: string;
  submitterName?: string | null;
  submittedAt: string;
}

export interface SubmissionDetail extends SubmissionSummary {
  values: Record<string, unknown>;
  fields: FormField[];
}

export interface ApiErrorBody {
  errors?: string[];
}

export const FIELD_TYPES: { type: FieldType; label: string; hint: string }[] = [
  { type: 'Text', label: 'טקסט קצר', hint: 'שם, מזהה, כותרת' },
  { type: 'TextArea', label: 'טקסט ארוך', hint: 'הערות והסברים' },
  { type: 'Number', label: 'מספר', hint: 'סכום, כמות, שנה' },
  { type: 'Date', label: 'תאריך', hint: 'תאריך דיווח' },
  { type: 'Email', label: 'דוא״ל', hint: 'כתובת אלקטרונית' },
  { type: 'Select', label: 'רשימה נפתחת', hint: 'בחירה מאפשרויות' },
  { type: 'Radio', label: 'בחירה יחידה', hint: 'כפתורי רדיו' },
  { type: 'Checkbox', label: 'תיבת סימון', hint: 'כן / לא' },
];
