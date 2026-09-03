using HrForms.Api.Domain;

namespace HrForms.Api.Store;

public class InMemoryFormTemplateStore : IFormTemplateStore
{
    private readonly object _gate = new();
    private readonly List<FormTemplate> _templates = [];
    private int _nextTemplateId = 1;
    private int _nextFieldId = 1;
    private int _nextStepId = 1;

    public FormTemplate Add(FormTemplate template)
    {
        lock (_gate)
        {
            template.Id = _nextTemplateId++;

            foreach (var field in template.Fields)
            {
                field.Id = _nextFieldId++;
            }

            foreach (var step in template.Steps)
            {
                step.Id = _nextStepId++;
            }

            _templates.Add(Clone(template));
            return Clone(template);
        }
    }

    public IReadOnlyList<FormTemplate> GetAll()
    {
        lock (_gate)
        {
            return _templates
                .OrderByDescending(t => t.CreatedAt)
                .Select(Clone)
                .ToList();
        }
    }

    public FormTemplate? GetById(int id)
    {
        lock (_gate)
        {
            var match = _templates.FirstOrDefault(t => t.Id == id);
            return match is null ? null : Clone(match);
        }
    }

    private static FormTemplate Clone(FormTemplate source) => new()
    {
        Id = source.Id,
        Name = source.Name,
        CreatedBy = source.CreatedBy,
        CreatedAt = source.CreatedAt,
        Fields = source.Fields.Select(f => new FormField
        {
            Id = f.Id,
            SortOrder = f.SortOrder,
            Label = f.Label,
            FieldType = f.FieldType,
            IsRequired = f.IsRequired
        }).ToList(),
        Steps = source.Steps.Select(s => new ApprovalStep
        {
            Id = s.Id,
            StepOrder = s.StepOrder,
            Name = s.Name,
            ApproverIdentity = s.ApproverIdentity,
            ActionType = s.ActionType
        }).ToList()
    };
}
