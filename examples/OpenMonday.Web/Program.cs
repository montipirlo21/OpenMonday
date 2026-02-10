using Microsoft.Extensions.Options;
using static ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<OpenMondayConfiguration>(
    builder.Configuration.GetSection("OpenMondayConfiguration"));

builder.Services.AddOptions<OpenMondayDriverOptions>()
.Configure<IOptions<OpenMondayConfiguration>>((driver, web) =>
{
    var cfg = web.Value;

    driver.MondayWebApiUrl = cfg.MondayWebApiUrl;
    driver.MondayToken = cfg.MondayToken;
    driver.MondayFileEndpoint = cfg.MondayFileEndpoint;
});

builder.Services.AddOpenMondayServices();

// Simulation AREA
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "OpenMonday Api Examples";
    options.Version = "v1";
    options.Description = "OpenMonday Api Examples";
});

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi();

app.UseAuthorization();
app.MapControllers();

app.Run();
