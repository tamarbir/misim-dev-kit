using Microsoft.EntityFrameworkCore;
using Misim.Forms.Api.Contracts;
using Misim.Forms.Api.Data;
using Misim.Forms.Api.Domain;
using Misim.Forms.Api.Mapping;
using Misim.Forms.Api.Validation;

namespace Misim.Forms.Api.Services;

public class FormService(FormsDbContext db)
{
    public async Task<IReadOnlyList<FormSummaryDto>> ListAsync(CancellationToken cancellationToken)
    {
        var forms = await db.Forms
            .AsNoTracking()
            .Include(f => f.Fields)
            .Include(f => f.Submissions)
            .ToListAsync(cancellationToken);

        return forms
            .OrderByDescending(f => f.UpdatedAt)
            .Select(FormMapper.ToSummary)
            .ToList();
    }

    public async Task<FormDetailDto?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var form = await db.Forms
            .AsNoTracking()
            .Include(f => f.Fields)
            .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);

        return form is null ? null : FormMapper.ToDetail(form);
    }

    public async Task<(FormDetailDto? Form, IReadOnlyList<string> Errors)> CreateAsync(
        UpsertFormRequest request,
        CancellationToken cancellationToken)
    {
        var errors = ValidateRequest(request);
        if (errors.Count > 0)
        {
            return (null, errors);
        }

        var now = DateTimeOffset.UtcNow;
        var form = new FormDefinition
        {
            Id = Guid.NewGuid(),
            Name = request.Name.Trim(),
            Description = request.Description?.Trim() ?? string.Empty,
            Status = FormStatus.Draft,
            CreatedAt = now,
            UpdatedAt = now
        };

        form.Fields = request.Fields
            .Select((field, index) => FormMapper.ToEntity(field with { Id = null }, form.Id, index))
            .ToList();

        db.Forms.Add(form);
        await db.SaveChangesAsync(cancellationToken);
        return (FormMapper.ToDetail(form), []);
    }

    public async Task<(FormDetailDto? Form, IReadOnlyList<string> Errors, bool NotFound)> UpdateAsync(
        Guid id,
        UpsertFormRequest request,
        CancellationToken cancellationToken)
    {
        var form = await db.Forms
            .Include(f => f.Fields)
            .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);

        if (form is null)
        {
            return (null, [], true);
        }

        var errors = ValidateRequest(request);
        if (errors.Count > 0)
        {
            return (null, errors, false);
        }

        form.Name = request.Name.Trim();
        form.Description = request.Description?.Trim() ?? string.Empty;
        form.UpdatedAt = DateTimeOffset.UtcNow;

        db.Fields.RemoveRange(form.Fields);
        form.Fields = request.Fields
            .Select((field, index) => FormMapper.ToEntity(field, form.Id, index))
            .ToList();

        await db.SaveChangesAsync(cancellationToken);
        return (FormMapper.ToDetail(form), [], false);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var form = await db.Forms.FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
        if (form is null)
        {
            return false;
        }

        db.Forms.Remove(form);
        await db.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<(FormDetailDto? Form, bool NotFound)> SetStatusAsync(
        Guid id,
        FormStatus status,
        CancellationToken cancellationToken)
    {
        var form = await db.Forms
            .Include(f => f.Fields)
            .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);

        if (form is null)
        {
            return (null, true);
        }

        form.Status = status;
        form.UpdatedAt = DateTimeOffset.UtcNow;
        await db.SaveChangesAsync(cancellationToken);
        return (FormMapper.ToDetail(form), false);
    }

    public async Task<(SubmissionDetailDto? Submission, IReadOnlyList<string> Errors, bool NotFound)> SubmitAsync(
        Guid formId,
        SubmitFormRequest request,
        CancellationToken cancellationToken)
    {
        var form = await db.Forms
            .Include(f => f.Fields)
            .FirstOrDefaultAsync(f => f.Id == formId, cancellationToken);

        if (form is null)
        {
            return (null, [], true);
        }

        if (form.Status != FormStatus.Published)
        {
            return (null, ["ניתן להגיש רק טפסים שפורסמו."], false);
        }

        var values = request.Values ?? new Dictionary<string, System.Text.Json.JsonElement>();
        var errors = SubmissionValidator.Validate(form, values);
        if (errors.Count > 0)
        {
            return (null, errors, false);
        }

        var submission = new FormSubmission
        {
            Id = Guid.NewGuid(),
            FormId = form.Id,
            SubmitterName = string.IsNullOrWhiteSpace(request.SubmitterName) ? null : request.SubmitterName.Trim(),
            ValuesJson = FormMapper.SerializeValues(values),
            SubmittedAt = DateTimeOffset.UtcNow
        };

        db.Submissions.Add(submission);
        await db.SaveChangesAsync(cancellationToken);
        return (FormMapper.ToDetail(submission, form), [], false);
    }

    public async Task<IReadOnlyList<SubmissionSummaryDto>> ListSubmissionsAsync(
        Guid formId,
        CancellationToken cancellationToken)
    {
        var rows = await db.Submissions
            .AsNoTracking()
            .Where(s => s.FormId == formId)
            .Join(db.Forms, s => s.FormId, f => f.Id, (s, f) => new { s, f.Name })
            .ToListAsync(cancellationToken);

        return rows
            .OrderByDescending(x => x.s.SubmittedAt)
            .Select(x => FormMapper.ToSummary(x.s, x.Name))
            .ToList();
    }

    public async Task<SubmissionDetailDto?> GetSubmissionAsync(Guid id, CancellationToken cancellationToken)
    {
        var submission = await db.Submissions
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        if (submission is null)
        {
            return null;
        }

        var form = await db.Forms
            .AsNoTracking()
            .Include(f => f.Fields)
            .FirstAsync(f => f.Id == submission.FormId, cancellationToken);

        return FormMapper.ToDetail(submission, form);
    }

    private static IReadOnlyList<string> ValidateRequest(UpsertFormRequest request) =>
        FormDefinitionValidator.Validate(
            request.Name,
            request.Fields.Select(f => (f.Key, f.Label, f.Type, f.Options)).ToList());
}
