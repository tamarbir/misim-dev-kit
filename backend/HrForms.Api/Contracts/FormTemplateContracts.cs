using HrForms.Api.Domain;

namespace HrForms.Api.Contracts;

public class CreateFormTemplateRequest
{
    public string Name { get; set; } = string.Empty;
    public string? CreatedBy { get; set; }
    public List<CreateFormFieldRequest> Fields { get; set; } = [];
    public List<CreateApprovalStepRequest> Steps { get; set; } = [];
}

public class CreateFormFieldRequest
{
    public string Label { get; set; } = string.Empty;
    public FieldType FieldType { get; set; }
    public bool IsRequired { get; set; }
}

public class CreateApprovalStepRequest
{
    public string Name { get; set; } = string.Empty;
    public string ApproverIdentity { get; set; } = string.Empty;
    public ApprovalActionType ActionType { get; set; }
}

public class FormTemplateListItemDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int FieldCount { get; set; }
    public int StepCount { get; set; }
}

public class FormFieldDto
{
    public int Id { get; set; }
    public int SortOrder { get; set; }
    public string Label { get; set; } = string.Empty;
    public FieldType FieldType { get; set; }
    public bool IsRequired { get; set; }
}

public class ApprovalStepDto
{
    public int Id { get; set; }
    public int StepOrder { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ApproverIdentity { get; set; } = string.Empty;
    public ApprovalActionType ActionType { get; set; }
}

public class FormTemplateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<FormFieldDto> Fields { get; set; } = [];
    public List<ApprovalStepDto> Steps { get; set; } = [];
}
