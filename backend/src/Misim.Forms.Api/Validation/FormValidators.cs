using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using Misim.Forms.Api.Domain;

namespace Misim.Forms.Api.Validation;

public static class FormDefinitionValidator
{
    private static readonly Regex KeyPattern = new("^[a-zA-Z][a-zA-Z0-9_]*$", RegexOptions.Compiled);

    public static IReadOnlyList<string> Validate(string name, IReadOnlyList<(string Key, string Label, FieldType Type, IReadOnlyList<string>? Options)> fields)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(name))
        {
            errors.Add("יש להזין שם לטופס.");
        }
        else if (name.Trim().Length > 200)
        {
            errors.Add("שם הטופס ארוך מדי.");
        }

        if (fields.Count == 0)
        {
            errors.Add("יש להוסיף לפחות שדה אחד.");
        }

        var keys = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var field in fields)
        {
            if (string.IsNullOrWhiteSpace(field.Key) || !KeyPattern.IsMatch(field.Key))
            {
                errors.Add($"מפתח שדה לא תקין: '{field.Key}'. יש להשתמש באותיות באנגלית, מספרים וקו תחתון.");
            }
            else if (!keys.Add(field.Key))
            {
                errors.Add($"מפתח שדה כפול: '{field.Key}'.");
            }

            if (string.IsNullOrWhiteSpace(field.Label))
            {
                errors.Add($"יש להזין תווית לשדה '{field.Key}'.");
            }

            if (field.Type is FieldType.Select or FieldType.Radio &&
                (field.Options is null || field.Options.Count == 0 || field.Options.All(string.IsNullOrWhiteSpace)))
            {
                errors.Add($"לשדה '{field.Label}' מסוג בחירה נדרשות אפשרויות.");
            }
        }

        return errors;
    }
}

public static class SubmissionValidator
{
    public static IReadOnlyList<string> Validate(FormDefinition form, IReadOnlyDictionary<string, JsonElement> values)
    {
        var errors = new List<string>();

        foreach (var field in form.Fields.OrderBy(f => f.SortOrder))
        {
            values.TryGetValue(field.Key, out var raw);
            var isMissing = raw.ValueKind is JsonValueKind.Undefined or JsonValueKind.Null
                            || (raw.ValueKind == JsonValueKind.String && string.IsNullOrWhiteSpace(raw.GetString()));

            if (field.Type == FieldType.Checkbox)
            {
                var checkedValue = raw.ValueKind == JsonValueKind.True
                                   || (raw.ValueKind == JsonValueKind.String && bool.TryParse(raw.GetString(), out var b) && b);
                if (field.Required && !checkedValue)
                {
                    errors.Add($"יש לסמן את השדה '{field.Label}'.");
                }

                continue;
            }

            if (field.Required && isMissing)
            {
                errors.Add($"השדה '{field.Label}' הוא שדה חובה.");
                continue;
            }

            if (isMissing)
            {
                continue;
            }

            switch (field.Type)
            {
                case FieldType.Number:
                    if (!TryGetNumber(raw, out var number))
                    {
                        errors.Add($"השדה '{field.Label}' חייב להיות מספר.");
                        break;
                    }

                    if (field.Min is { } min && number < min)
                    {
                        errors.Add($"השדה '{field.Label}' חייב להיות לפחות {min}.");
                    }

                    if (field.Max is { } max && number > max)
                    {
                        errors.Add($"השדה '{field.Label}' חייב להיות לכל היותר {max}.");
                    }

                    break;

                case FieldType.Email:
                    var email = GetString(raw);
                    if (!string.IsNullOrWhiteSpace(email) && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    {
                        errors.Add($"השדה '{field.Label}' חייב להיות כתובת דוא\"ל תקינה.");
                    }

                    ValidateTextConstraints(field, email, errors);
                    break;

                case FieldType.Select:
                case FieldType.Radio:
                    var selected = GetString(raw);
                    var options = ParseOptions(field.OptionsJson);
                    if (options.Count > 0 && !options.Contains(selected))
                    {
                        errors.Add($"הערך בשדה '{field.Label}' אינו אחד מהאפשרויות המותרות.");
                    }

                    break;

                case FieldType.Date:
                    var dateText = GetString(raw);
                    if (!DateOnly.TryParse(dateText, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                    {
                        errors.Add($"השדה '{field.Label}' חייב להיות תאריך תקין.");
                    }

                    break;

                default:
                    ValidateTextConstraints(field, GetString(raw), errors);
                    break;
            }
        }

        return errors;
    }

    private static void ValidateTextConstraints(FormField field, string text, List<string> errors)
    {
        if (field.MinLength is { } minLength && text.Length < minLength)
        {
            errors.Add($"השדה '{field.Label}' חייב להכיל לפחות {minLength} תווים.");
        }

        if (field.MaxLength is { } maxLength && text.Length > maxLength)
        {
            errors.Add($"השדה '{field.Label}' אינו יכול להכיל יותר מ-{maxLength} תווים.");
        }

        if (!string.IsNullOrWhiteSpace(field.Pattern) && !Regex.IsMatch(text, field.Pattern))
        {
            errors.Add($"השדה '{field.Label}' אינו תואם את התבנית הנדרשת.");
        }
    }

    private static string GetString(JsonElement raw) =>
        raw.ValueKind == JsonValueKind.String ? raw.GetString() ?? string.Empty : raw.ToString();

    private static bool TryGetNumber(JsonElement raw, out double number)
    {
        if (raw.ValueKind == JsonValueKind.Number)
        {
            return raw.TryGetDouble(out number);
        }

        return double.TryParse(GetString(raw), NumberStyles.Number, CultureInfo.InvariantCulture, out number);
    }

    private static List<string> ParseOptions(string? json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return [];
        }

        return JsonSerializer.Deserialize<List<string>>(json) ?? [];
    }
}
