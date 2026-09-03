namespace Misim.Forms.Api.Domain;

public class FormSubmission
{
    public Guid Id { get; set; }
    public Guid FormId { get; set; }
    public string? SubmitterName { get; set; }
    public string ValuesJson { get; set; } = "{}";
    public DateTimeOffset SubmittedAt { get; set; }

    public FormDefinition Form { get; set; } = null!;
}
