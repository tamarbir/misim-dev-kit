using HrForms.Api.Contracts;

namespace HrForms.Api.Services;

public interface IFormTemplateService
{
    FormTemplateDto Create(CreateFormTemplateRequest request);
    IReadOnlyList<FormTemplateListItemDto> GetAll();
    FormTemplateDto? GetById(int id);
}
