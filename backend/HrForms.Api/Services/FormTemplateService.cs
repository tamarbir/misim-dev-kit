using HrForms.Api.Contracts;
using HrForms.Api.Domain;
using HrForms.Api.Store;

namespace HrForms.Api.Services;

public class FormTemplateService : IFormTemplateService
{
    private readonly IFormTemplateStore _store;

    public FormTemplateService(IFormTemplateStore store)
    {
        _store = store;
    }

    public FormTemplateDto Create(CreateFormTemplateRequest request)
    {
        var errors = Validate(request);
        if (errors.Count > 0)
        {
            throw new FormValidationException(errors);
        }

        var template = new FormTemplate
        {
            Name = request.Name.Trim(),
            CreatedBy = string.IsNullOrWhiteSpace(request.CreatedBy)
                ? "מערכת"
                : request.CreatedBy.Trim(),
            CreatedAt = DateTime.UtcNow,
            Fields = request.Fields.Select((field, index) => new FormField
            {
                SortOrder = index + 1,
                Label = field.Label.Trim(),
                FieldType = field.FieldType,
                IsRequired = field.IsRequired
            }).ToList(),
            Steps = request.Steps.Select((step, index) => new ApprovalStep
            {
                StepOrder = index + 1,
                Name = step.Name.Trim(),
                ApproverIdentity = step.ApproverIdentity.Trim(),
                ActionType = step.ActionType
            }).ToList()
        };

        return MapDetails(_store.Add(template));
    }

    public IReadOnlyList<FormTemplateListItemDto> GetAll() =>
        _store.GetAll().Select(t => new FormTemplateListItemDto
        {
            Id = t.Id,
            Name = t.Name,
            CreatedBy = t.CreatedBy,
            CreatedAt = t.CreatedAt,
            FieldCount = t.Fields.Count,
            StepCount = t.Steps.Count
        }).ToList();

    public FormTemplateDto? GetById(int id)
    {
        var template = _store.GetById(id);
        return template is null ? null : MapDetails(template);
    }

    private static List<string> Validate(CreateFormTemplateRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            errors.Add("שם הטופס הוא שדה חובה.");
        }

        if (request.Fields.Count == 0)
        {
            errors.Add("יש להוסיף לפחות שדה אחד לטופס.");
        }

        for (var i = 0; i < request.Fields.Count; i++)
        {
            var field = request.Fields[i];
            if (string.IsNullOrWhiteSpace(field.Label))
            {
                errors.Add($"לשדה מספר {i + 1} חסרה תווית.");
            }

            if (!Enum.IsDefined(field.FieldType))
            {
                errors.Add($"לשדה מספר {i + 1} סוג לא חוקי.");
            }
        }

        if (request.Steps.Count == 0)
        {
            errors.Add("יש להוסיף לפחות אבן דרך אחת.");
        }

        for (var i = 0; i < request.Steps.Count; i++)
        {
            var step = request.Steps[i];
            if (string.IsNullOrWhiteSpace(step.Name))
            {
                errors.Add($"לאבן דרך מספר {i + 1} חסר שם שלב.");
            }

            if (string.IsNullOrWhiteSpace(step.ApproverIdentity))
            {
                errors.Add($"לאבן דרך מספר {i + 1} חסרה זהות מאשר.");
            }

            if (!Enum.IsDefined(step.ActionType))
            {
                errors.Add($"לאבן דרך מספר {i + 1} סוג פעולה לא חוקי.");
            }
        }

        return errors;
    }

    private static FormTemplateDto MapDetails(FormTemplate template) => new()
    {
        Id = template.Id,
        Name = template.Name,
        CreatedBy = template.CreatedBy,
        CreatedAt = template.CreatedAt,
        Fields = template.Fields.OrderBy(f => f.SortOrder).Select(f => new FormFieldDto
        {
            Id = f.Id,
            SortOrder = f.SortOrder,
            Label = f.Label,
            FieldType = f.FieldType,
            IsRequired = f.IsRequired
        }).ToList(),
        Steps = template.Steps.OrderBy(s => s.StepOrder).Select(s => new ApprovalStepDto
        {
            Id = s.Id,
            StepOrder = s.StepOrder,
            Name = s.Name,
            ApproverIdentity = s.ApproverIdentity,
            ActionType = s.ActionType
        }).ToList()
    };
}

public class FormValidationException : Exception
{
    public IReadOnlyList<string> Errors { get; }

    public FormValidationException(IReadOnlyList<string> errors)
        : base("שמירת הטופס נכשלה עקב שגיאות ולידציה.")
    {
        Errors = errors;
    }
}
