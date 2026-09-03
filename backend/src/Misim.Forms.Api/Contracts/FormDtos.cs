using System.Text.Json;
using Misim.Forms.Api.Domain;

namespace Misim.Forms.Api.Contracts;

public record FormSummaryDto(
    Guid Id,
    string Name,
    string Description,
    FormStatus Status,
    int FieldCount,
    int SubmissionCount,
    DateTimeOffset UpdatedAt);

public record FormFieldDto(
    Guid? Id,
    string Key,
    string Label,
    FieldType Type,
    bool Required,
    string? Placeholder,
    string? HelpText,
    int SortOrder,
    IReadOnlyList<string>? Options,
    double? Min,
    double? Max,
    int? MinLength,
    int? MaxLength,
    string? Pattern);

public record FormDetailDto(
    Guid Id,
    string Name,
    string Description,
    FormStatus Status,
    IReadOnlyList<FormFieldDto> Fields,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);

public record UpsertFormRequest(
    string Name,
    string Description,
    IReadOnlyList<FormFieldDto> Fields);

public record SubmitFormRequest(
    string? SubmitterName,
    Dictionary<string, JsonElement>? Values);

public record SubmissionSummaryDto(
    Guid Id,
    Guid FormId,
    string FormName,
    string? SubmitterName,
    DateTimeOffset SubmittedAt);

public record SubmissionDetailDto(
    Guid Id,
    Guid FormId,
    string FormName,
    string? SubmitterName,
    DateTimeOffset SubmittedAt,
    IReadOnlyDictionary<string, JsonElement> Values,
    IReadOnlyList<FormFieldDto> Fields);
