using MachineAssetManagement.Components;
using MachineAssetManagement.Data;
using MachineAssetManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Razor / Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Web API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HttpClient
builder.Services.AddHttpClient();

// Parsers
builder.Services.AddSingleton<TxtParser>();
builder.Services.AddSingleton<JsonParser>();
builder.Services.AddSingleton<ParserFactory>();

// Resolve Matrix file path ONCE
var dataFilePath =
    builder.Configuration.GetValue<string>("DataSettings:MatrixFilePath")
    ?? Path.Combine(builder.Environment.ContentRootPath, "Data", "Matrix.txt");

// Make absolute path
dataFilePath = Path.Combine(
    builder.Environment.ContentRootPath,
    dataFilePath
);

// Register services that NEED the path
builder.Services.AddScoped<MatrixFileService>(sp =>
    new MatrixFileService(dataFilePath));

builder.Services.AddScoped<IMachineService>(sp =>
    new MachineService(
        sp.GetRequiredService<ParserFactory>(),
        dataFilePath
    ));

//builder.Services.AddScoped<IAssetService>(sp =>
//    new AssetService(
//        sp.GetRequiredService<ParserFactory>(),
//        dataFilePath
//    ));

builder.Services.AddScoped<UploadService>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

// Endpoints
app.MapControllers();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
