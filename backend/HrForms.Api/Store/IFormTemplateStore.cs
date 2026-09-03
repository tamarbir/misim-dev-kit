using HrForms.Api.Domain;

namespace HrForms.Api.Store;

public interface IFormTemplateStore
{
    FormTemplate Add(FormTemplate template);
    IReadOnlyList<FormTemplate> GetAll();
    FormTemplate? GetById(int id);
}
