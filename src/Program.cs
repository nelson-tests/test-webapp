using System.Reflection;

var version = Assembly.GetEntryAssembly()?.GetName()?.Version;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => $"Welcome to Minimal API - {version}");
app.MapGet("/machine", () => Environment.MachineName);
app.MapGet("/version", () => version);
app.MapGet("/framework-version", () => Environment.Version);
app.MapGet("/os", () => $"{Environment.OSVersion.Platform} - {Environment.OSVersion.VersionString}");

app.Run();
