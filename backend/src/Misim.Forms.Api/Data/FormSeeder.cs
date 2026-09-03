using Microsoft.EntityFrameworkCore;
using Misim.Forms.Api.Data;
using Misim.Forms.Api.Domain;

namespace Misim.Forms.Api.Data;

public static class FormSeeder
{
    public static async Task SeedAsync(FormsDbContext db)
    {
        if (await db.Forms.AnyAsync())
        {
            return;
        }

        var now = DateTimeOffset.UtcNow;
        var formId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");

        db.Forms.Add(new FormDefinition
        {
            Id = formId,
            Name = "דיווח הכנסה שנתית",
            Description = "טופס לדוגמה לדיווח הכנסה לרשות המסים. ניתן לערוך אותו בבונה הטפסים או למלא אותו ישירות.",
            Status = FormStatus.Published,
            CreatedAt = now,
            UpdatedAt = now,
            Fields =
            [
                Field(formId, "fullName", "שם מלא", FieldType.Text, 0, required: true, placeholder: "שם פרטי ושם משפחה", minLength: 2, maxLength: 80),
                Field(formId, "nationalId", "מספר זהות", FieldType.Text, 1, required: true, placeholder: "9 ספרות", help: "יש להזין מספר זהות בן 9 ספרות.", pattern: @"^\d{9}$", minLength: 9, maxLength: 9),
                Field(formId, "email", "דוא\"ל", FieldType.Email, 2, required: true, placeholder: "name@example.com"),
                Field(formId, "taxYear", "שנת המס", FieldType.Number, 3, required: true, min: 2000, max: 2026),
                Field(formId, "reportType", "סוג דיווח", FieldType.Select, 4, required: true, optionsJson: """["שכיר","עצמאי","חברה"]"""),
                Field(formId, "incomeAmount", "סכום הכנסה (₪)", FieldType.Number, 5, required: true, min: 0),
                Field(formId, "hasForeignIncome", "יש לי הכנסה מחו\"ל", FieldType.Checkbox, 6),
                Field(formId, "notes", "הערות", FieldType.TextArea, 7, placeholder: "פרטים נוספים לדיווח", maxLength: 500)
            ]
        });

        await db.SaveChangesAsync();
    }

    private static FormField Field(
        Guid formId,
        string key,
        string label,
        FieldType type,
        int order,
        bool required = false,
        string? placeholder = null,
        string? help = null,
        string? pattern = null,
        string? optionsJson = null,
        double? min = null,
        double? max = null,
        int? minLength = null,
        int? maxLength = null) =>
        new()
        {
            Id = Guid.NewGuid(),
            FormId = formId,
            Key = key,
            Label = label,
            Type = type,
            Required = required,
            Placeholder = placeholder,
            HelpText = help,
            SortOrder = order,
            OptionsJson = optionsJson,
            Min = min,
            Max = max,
            MinLength = minLength,
            MaxLength = maxLength,
            Pattern = pattern
        };
}
