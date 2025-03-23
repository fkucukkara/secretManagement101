var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/reveal-secret", (IConfiguration config) =>
{
    var apiKey = config["ServiceApiKey"];
    return apiKey;
});

app.Run();
