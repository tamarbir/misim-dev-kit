using System.Text.Json;
using Misim.Forms.Api.Contracts;
using Misim.Forms.Api.Domain;

namespace Misim.Forms.Api.Mapping;

public static class FormMapper
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static FormSummaryDto ToSummary(FormDefinition form) =>
        new(
            form.Id,
            form.Name,
            form.Description,
            form.Status,
            form.Fields.Count,
            form.Submissions.Count,
            form.UpdatedAt);

    public static FormFieldDto ToDto(FormField field) =>
        new(
            field.Id,
            field.Key,
            field.Label,
            field.Type,
            field.Required,
            field.Placeholder,
            field.HelpText,
            field.SortOrder,
            ParseOptions(field.OptionsJson),
            field.Min,
            field.Max,
            field.MinLength,
            field.MaxLength,
            field.Pattern);

    public static FormDetailDto ToDetail(FormDefinition form) =>
        new(
            form.Id,
            form.Name,
            form.Description,
            form.Status,
            form.Fields.OrderBy(f => f.SortOrder).Select(ToDto).ToList(),
            form.CreatedAt,
            form.UpdatedAt);

    public static FormField ToEntity(FormFieldDto dto, Guid formId, int fallbackOrder)
    {
        return new FormField
        {
            Id = dto.Id is { } id && id != Guid.Empty ? id : Guid.NewGuid(),
            FormId = formId,
            Key = dto.Key.Trim(),
            Label = dto.Label.Trim(),
            Type = dto.Type,
            Required = dto.Required,
            Placeholder = NullIfEmpty(dto.Placeholder),
            HelpText = NullIfEmpty(dto.HelpText),
            SortOrder = dto.SortOrder >= 0 ? dto.SortOrder : fallbackOrder,
            OptionsJson = dto.Options is { Count: > 0 }
                ? JsonSerializer.Serialize(dto.Options, JsonOptions)
                : null,
            Min = dto.Min,
            Max = dto.Max,
            MinLength = dto.MinLength,
            MaxLength = dto.MaxLength,
            Pattern = NullIfEmpty(dto.Pattern)
        };
    }

    public static SubmissionSummaryDto ToSummary(FormSubmission submission, string formName) =>
        new(submission.Id, submission.FormId, formName, submission.SubmitterName, submission.SubmittedAt);

    public static SubmissionDetailDto ToDetail(FormSubmission submission, FormDefinition form)
    {
        var values = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(submission.ValuesJson, JsonOptions)
                     ?? new Dictionary<string, JsonElement>();

        return new SubmissionDetailDto(
            submission.Id,
            form.Id,
            form.Name,
            submission.SubmitterName,
            submission.SubmittedAt,
            values,
            form.Fields.OrderBy(f => f.SortOrder).Select(ToDto).ToList());
    }

    public static string SerializeValues(Dictionary<string, JsonElement> values) =>
        JsonSerializer.Serialize(values, JsonOptions);

    private static IReadOnlyList<string>? ParseOptions(string? json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return null;
        }

        return JsonSerializer.Deserialize<List<string>>(json, JsonOptions);
    }

    private static string? NullIfEmpty(string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
