using MachineAssetManagement.Components;
using MachineAssetManagement.Data;
using MachineAssetManagement.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient();



var dataFilePath =
    builder.Configuration.GetValue<string>("DataSettings:MatrixFilePath")
    ?? Path.Combine(builder.Environment.ContentRootPath, "Data", "Matrix.txt");;

builder.Services.AddScoped<MatrixFileService>(sp =>
{
    return new MatrixFileService(dataFilePath);
});

builder.Services.AddScoped<IMachineService,MachineService>();

builder.Services.AddSingleton<IDataParser, JsonParser>();
builder.Services.AddSingleton<IDataParser, TxtParser>();
builder.Services.AddSingleton<Repository>(sp =>
{
    var parsers = sp.GetRequiredService<IEnumerable<IDataParser>>(); 
    return new Repository(parsers, dataFilePath);
});



builder.Services.AddScoped<UploadService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAntiforgery();


app.MapControllers();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
