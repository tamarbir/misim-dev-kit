export type FieldType = 'Text' | 'Date';
export type ApprovalActionType = 'Approve' | 'Reject' | 'ApproveOrReject';

export interface FormField {
  id: number;
  sortOrder: number;
  label: string;
  fieldType: FieldType;
  isRequired: boolean;
}

export interface ApprovalStep {
  id: number;
  stepOrder: number;
  name: string;
  approverIdentity: string;
  actionType: ApprovalActionType;
}

export interface FormTemplate {
  id: number;
  name: string;
  createdBy: string;
  createdAt: string;
  fields: FormField[];
  steps: ApprovalStep[];
}

export interface FormTemplateListItem {
  id: number;
  name: string;
  createdBy: string;
  createdAt: string;
  fieldCount: number;
  stepCount: number;
}

export interface CreateFormFieldRequest {
  label: string;
  fieldType: FieldType;
  isRequired: boolean;
}

export interface CreateApprovalStepRequest {
  name: string;
  approverIdentity: string;
  actionType: ApprovalActionType;
}

export interface CreateFormTemplateRequest {
  name: string;
  createdBy?: string;
  fields: CreateFormFieldRequest[];
  steps: CreateApprovalStepRequest[];
}

export const FIELD_TYPE_LABEL: Record<FieldType, string> = {
  Text: 'טקסט',
  Date: 'תאריך',
};

export const ACTION_TYPE_LABEL: Record<ApprovalActionType, string> = {
  Approve: 'אישור בלבד',
  Reject: 'דחייה בלבד',
  ApproveOrReject: 'אישור או דחייה',
};
