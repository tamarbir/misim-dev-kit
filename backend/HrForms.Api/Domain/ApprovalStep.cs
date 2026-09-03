namespace HrForms.Api.Domain;

public class ApprovalStep
{
    public int Id { get; set; }
    public int StepOrder { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ApproverIdentity { get; set; } = string.Empty;
    public ApprovalActionType ActionType { get; set; }
}
