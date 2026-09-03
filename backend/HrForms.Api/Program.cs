using System.Text.Json.Serialization;
using HrForms.Api.Services;
using HrForms.Api.Store;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IFormTemplateStore, InMemoryFormTemplateStore>();
builder.Services.AddScoped<IFormTemplateService, FormTemplateService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "HR Forms API",
        Version = "v1",
        Description = "PoC לבניית טפסים ואבני דרך. הנתונים נשמרים בזיכרון בלבד."
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.MapControllers();
app.Run();
