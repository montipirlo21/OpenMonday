var builder = WebApplication.CreateBuilder(args);

// Retrieve the configuration from app.settings or env
builder.Services.Configure<OpenMondayConfiguration>(builder.Configuration.GetSection("OpenMondayConfiguration"));
var openMondayConfiguration = new OpenMondayConfiguration();
builder.Configuration.GetSection("OpenMondayConfiguration").Bind(openMondayConfiguration);

builder.Services.AddOpenMondayServices(options =>
{
    options.MondayWebApiUrl = openMondayConfiguration.MondayWebApiUrl;
    options.MondayToken = openMondayConfiguration.MondayToken;
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
