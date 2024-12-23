using static ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

// AddOpenMondayServices 
builder.Services.AddOpenMondayServices(() =>
{
    var currentOptions = new OpenMondayConfiguration();
    builder.Configuration.GetSection("OpenMondayConfiguration").Bind(currentOptions);

    return new OpenMondayDriverOptions
    {
        MondayWebApiUrl = currentOptions.MondayWebApiUrl,
        MondayToken = currentOptions.MondayToken
    };
});

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
