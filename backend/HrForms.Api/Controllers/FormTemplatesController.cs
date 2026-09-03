using HrForms.Api.Contracts;
using HrForms.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HrForms.Api.Controllers;

[ApiController]
[Route("api/form-templates")]
public class FormTemplatesController : ControllerBase
{
    private readonly IFormTemplateService _service;

    public FormTemplatesController(IFormTemplateService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<FormTemplateListItemDto>> GetAll()
        => Ok(_service.GetAll());

    [HttpGet("{id:int}")]
    public ActionResult<FormTemplateDto> GetById(int id)
    {
        var template = _service.GetById(id);
        return template is null ? NotFound() : Ok(template);
    }

    [HttpPost]
    public ActionResult<FormTemplateDto> Create(CreateFormTemplateRequest request)
    {
        try
        {
            var created = _service.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (FormValidationException ex)
        {
            return BadRequest(new { errors = ex.Errors });
        }
    }
}
