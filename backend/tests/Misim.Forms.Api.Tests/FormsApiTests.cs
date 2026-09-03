using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Misim.Forms.Api.Tests;

public class FormsApiTests : IClassFixture<FormsApiFactory>
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly HttpClient _client;

    public FormsApiTests(FormsApiFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Health_ReturnsOk()
    {
        var response = await _client.GetAsync("/health");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task SeededForm_CanBeListedAndFetched()
    {
        var list = await _client.GetFromJsonAsync<List<JsonElement>>("/api/forms");
        Assert.NotNull(list);
        Assert.NotEmpty(list);

        var id = list![0].GetProperty("id").GetGuid();
        var detail = await _client.GetAsync($"/api/forms/{id}");
        Assert.Equal(HttpStatusCode.OK, detail.StatusCode);
    }

    [Fact]
    public async Task CreateForm_ThenSubmit_WhenPublished()
    {
        var createResponse = await _client.PostAsJsonAsync("/api/forms", new
        {
            name = "טופס בדיקה",
            description = "טופס לאוטומציה",
            fields = new object[]
            {
                new
                {
                    key = "fullName",
                    label = "שם מלא",
                    type = "Text",
                    required = true,
                    sortOrder = 0,
                    minLength = 2
                },
                new
                {
                    key = "agree",
                    label = "מאשר",
                    type = "Checkbox",
                    required = true,
                    sortOrder = 1
                }
            }
        });

        Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
        using var created = JsonDocument.Parse(await createResponse.Content.ReadAsStringAsync());
        var id = created.RootElement.GetProperty("id").GetGuid();

        var unpublishedSubmit = await _client.PostAsJsonAsync($"/api/forms/{id}/submissions", new
        {
            submitterName = "בודק",
            values = new { fullName = "ישראל ישראלי", agree = true }
        });
        Assert.Equal(HttpStatusCode.UnprocessableEntity, unpublishedSubmit.StatusCode);

        var publish = await _client.PostAsync($"/api/forms/{id}/publish", null);
        Assert.Equal(HttpStatusCode.OK, publish.StatusCode);

        var invalidSubmit = await _client.PostAsJsonAsync($"/api/forms/{id}/submissions", new
        {
            submitterName = "בודק",
            values = new { fullName = "י", agree = false }
        });
        Assert.Equal(HttpStatusCode.UnprocessableEntity, invalidSubmit.StatusCode);

        var validSubmit = await _client.PostAsJsonAsync($"/api/forms/{id}/submissions", new
        {
            submitterName = "בודק",
            values = new { fullName = "ישראל ישראלי", agree = true }
        });
        Assert.Equal(HttpStatusCode.Created, validSubmit.StatusCode);

        var submissions = await _client.GetFromJsonAsync<List<JsonElement>>($"/api/forms/{id}/submissions", JsonOptions);
        Assert.Single(submissions!);
    }

    [Fact]
    public async Task CreateForm_RejectsDuplicateKeys()
    {
        var response = await _client.PostAsJsonAsync("/api/forms", new
        {
            name = "טופס כפול",
            description = "",
            fields = new object[]
            {
                new { key = "name", label = "שם", type = "Text", required = true, sortOrder = 0 },
                new { key = "name", label = "שם נוסף", type = "Text", required = false, sortOrder = 1 }
            }
        });

        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
    }
}
