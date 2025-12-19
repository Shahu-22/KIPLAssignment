using MachineAssetManagement.Components;
using MachineAssetManagement.Data;
using MachineAssetManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//add httpclient
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(
        builder.Configuration["ApiSettings:BaseUrl"]);
});

//registration files
builder.Services.AddSingleton<IDataParser, TxtParser>();

builder.Services.AddSingleton<Repository>();

builder.Services.AddScoped<IMachineService>(sp =>
{
    var env = sp.GetRequiredService<IWebHostEnvironment>();
    var filePath = Path.Combine(env.ContentRootPath, "Data", "Matrix.txt");

    return new MachineService(
        sp.GetRequiredService<Repository>(),
        filePath
    );
});
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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
