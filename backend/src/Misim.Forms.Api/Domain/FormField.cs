namespace Misim.Forms.Api.Domain;

public class FormField
{
    public Guid Id { get; set; }
    public Guid FormId { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public FieldType Type { get; set; }
    public bool Required { get; set; }
    public string? Placeholder { get; set; }
    public string? HelpText { get; set; }
    public int SortOrder { get; set; }
    public string? OptionsJson { get; set; }
    public double? Min { get; set; }
    public double? Max { get; set; }
    public int? MinLength { get; set; }
    public int? MaxLength { get; set; }
    public string? Pattern { get; set; }

    public FormDefinition Form { get; set; } = null!;
}
