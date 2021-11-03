var builder = WebApplication.CreateBuilder(args);

string? nextHop = Environment.GetEnvironmentVariable("nextHop");
string response = Environment.GetEnvironmentVariable("responseMessage") ?? "Hello from C# link";
HttpClient? httpClient = nextHop != null ? new HttpClient { BaseAddress = new Uri(nextHop) } : null;

var app = builder.Build();

app.MapGet("/", async () => {
    return new {
        response = response,
        nestedResponse = httpClient != null ?
                new { response = await httpClient.GetStringAsync(nextHop) } :
                null
    };
});

app.Run();