var builder = WebApplication.CreateBuilder(args);

// Retrieve the configuration from app.settings or env
builder.Services.Configure<OpenMondayConfiguration>(builder.Configuration.GetSection("OpenMondayConfiguration"));
var openMondayConfiguration = new OpenMondayConfiguration();
builder.Configuration.GetSection("OpenMondayConfiguration").Bind(openMondayConfiguration);

// AddOpenMondayServices 
builder.Services.AddOpenMondayServices(options =>
{
    options.MondayWebApiUrl = openMondayConfiguration.MondayWebApiUrl;
    options.MondayToken = openMondayConfiguration.MondayToken;
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
