namespace Misim.Forms.Api.Domain;

public class FormDefinition
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public FormStatus Status { get; set; } = FormStatus.Draft;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public List<FormField> Fields { get; set; } = [];
    public List<FormSubmission> Submissions { get; set; } = [];
}
