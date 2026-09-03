using Microsoft.AspNetCore.Mvc;
using Misim.Forms.Api.Contracts;
using Misim.Forms.Api.Domain;
using Misim.Forms.Api.Services;

namespace Misim.Forms.Api.Controllers;

[ApiController]
[Route("api/forms")]
public class FormsController(FormService forms) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<FormSummaryDto>>> List(CancellationToken cancellationToken)
        => Ok(await forms.ListAsync(cancellationToken));

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FormDetailDto>> Get(Guid id, CancellationToken cancellationToken)
    {
        var form = await forms.GetAsync(id, cancellationToken);
        return form is null ? NotFound() : Ok(form);
    }

    [HttpPost]
    public async Task<ActionResult<FormDetailDto>> Create(
        [FromBody] UpsertFormRequest request,
        CancellationToken cancellationToken)
    {
        var (form, errors) = await forms.CreateAsync(request, cancellationToken);
        if (errors.Count > 0)
        {
            return Unprocessable(errors);
        }

        return CreatedAtAction(nameof(Get), new { id = form!.Id }, form);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<FormDetailDto>> Update(
        Guid id,
        [FromBody] UpsertFormRequest request,
        CancellationToken cancellationToken)
    {
        var (form, errors, notFound) = await forms.UpdateAsync(id, request, cancellationToken);
        if (notFound)
        {
            return NotFound();
        }

        if (errors.Count > 0)
        {
            return Unprocessable(errors);
        }

        return Ok(form);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        => await forms.DeleteAsync(id, cancellationToken) ? NoContent() : NotFound();

    [HttpPost("{id:guid}/publish")]
    public async Task<ActionResult<FormDetailDto>> Publish(Guid id, CancellationToken cancellationToken)
    {
        var (form, notFound) = await forms.SetStatusAsync(id, FormStatus.Published, cancellationToken);
        return notFound ? NotFound() : Ok(form);
    }

    [HttpPost("{id:guid}/unpublish")]
    public async Task<ActionResult<FormDetailDto>> Unpublish(Guid id, CancellationToken cancellationToken)
    {
        var (form, notFound) = await forms.SetStatusAsync(id, FormStatus.Draft, cancellationToken);
        return notFound ? NotFound() : Ok(form);
    }

    [HttpPost("{id:guid}/submissions")]
    public async Task<ActionResult<SubmissionDetailDto>> Submit(
        Guid id,
        [FromBody] SubmitFormRequest request,
        CancellationToken cancellationToken)
    {
        var (submission, errors, notFound) = await forms.SubmitAsync(id, request, cancellationToken);
        if (notFound)
        {
            return NotFound();
        }

        if (errors.Count > 0)
        {
            return Unprocessable(errors);
        }

        return Created($"/api/submissions/{submission!.Id}", submission);
    }

    [HttpGet("{id:guid}/submissions")]
    public async Task<ActionResult<IReadOnlyList<SubmissionSummaryDto>>> ListSubmissions(
        Guid id,
        CancellationToken cancellationToken)
    {
        if (await forms.GetAsync(id, cancellationToken) is null)
        {
            return NotFound();
        }

        return Ok(await forms.ListSubmissionsAsync(id, cancellationToken));
    }

    private ActionResult Unprocessable(IReadOnlyList<string> errors) =>
        UnprocessableEntity(new { errors });
}

[ApiController]
[Route("api/submissions")]
public class SubmissionsController(FormService forms) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SubmissionDetailDto>> Get(Guid id, CancellationToken cancellationToken)
    {
        var submission = await forms.GetSubmissionAsync(id, cancellationToken);
        return submission is null ? NotFound() : Ok(submission);
    }
}
