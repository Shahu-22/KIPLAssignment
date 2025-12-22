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
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(
        builder.Configuration["ApiSettings:BaseUrl"]);
});

// Data layer
builder.Services.AddSingleton<IDataParser, TxtParser>();
builder.Services.AddSingleton<Repository>();

// Services
builder.Services.AddScoped<IMachineService>(sp =>
{
    var env = sp.GetRequiredService<IWebHostEnvironment>();
    var filePath = Path.Combine(env.ContentRootPath, "Data", "Matrix.txt");

    return new MachineService(
        sp.GetRequiredService<Repository>(),
        filePath
    );
});
builder.Services.AddSingleton<MatrixFileService>();
builder.Services.AddScoped<UploadService>();


builder.Services.AddScoped<IAssetService>(sp =>
{
    var env = sp.GetRequiredService<IWebHostEnvironment>();
    var filePath = Path.Combine(env.ContentRootPath, "Data", "Matrix.txt");

    return new AssetService(
        sp.GetRequiredService<Repository>(),
        filePath
    );
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

// Map API + Blazor
app.MapControllers();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
