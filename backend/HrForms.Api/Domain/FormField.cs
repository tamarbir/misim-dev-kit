namespace HrForms.Api.Domain;

public class FormField
{
    public int Id { get; set; }
    public int SortOrder { get; set; }
    public string Label { get; set; } = string.Empty;
    public FieldType FieldType { get; set; }
    public bool IsRequired { get; set; }
}
