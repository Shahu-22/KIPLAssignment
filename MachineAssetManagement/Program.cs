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

builder.Services.AddScoped<IMachineService,MachineService>();

builder.Services.AddSingleton<IDataParser, JsonParser>();
builder.Services.AddSingleton<IDataParser, TxtParser>();

//var dataFilePath =
//    builder.Configuration.GetValue<string>("MatrixFilePath")
//    ?? Path.Combine(builder.Environment.ContentRootPath, "Data", "Matrix.txt");
//builder.Services.AddScoped<IDataLoader>(sp =>
//{
//    var _repo = sp.GetRequiredService<IRepository>();
//    return new FileDataLoader(dataFilePath,_repo);
//});

//builder.Services.AddSingleton<IRepository>(sp =>
//{
//    var parsers = sp.GetRequiredService<IEnumerable<IDataParser>>();
//    return new Repository(parsers, dataFilePath);
//});

builder.Services.AddSingleton<IRepository>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString =
        configuration["MongoSettings:ConnectionString"]
        ?? "mongodb://admin:qwerty@mongo:27017";

    var parsers = sp.GetRequiredService<IEnumerable<IDataParser>>();
    return new RepositoryDB(parsers, connectionString);
});

builder.Services.AddScoped<IDataLoader>(sp =>
{
    var _repo = sp.GetRequiredService<IRepository>();
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration["MongoSettings:ConnectionString"] ?? "mongodb://admin:qwerty@mongo:27017";
    return new DbDataLoader(connectionString, _repo);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAntiforgery();


app.MapControllers();
app.UseStaticFiles();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
