var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Welcome to Minimal API");
app.MapGet("/machine", () => Environment.MachineName);
app.MapGet("/version", () => Environment.Version);
app.MapGet("/os", () => $"{Environment.OSVersion.Platform} - {Environment.OSVersion.VersionString}");

app.Run();
