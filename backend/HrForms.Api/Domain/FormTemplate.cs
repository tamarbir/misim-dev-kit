namespace HrForms.Api.Domain;

public class FormTemplate
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<FormField> Fields { get; set; } = [];
    public List<ApprovalStep> Steps { get; set; } = [];
}
