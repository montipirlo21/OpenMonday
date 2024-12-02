# Installation Guide for using OpenMonday

You can check the example project referencing the nuget package instead of the source project 

1. Reference the OpenMonday nuget package

```bash
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
```

where OpenMondayConfiguration

```bash
public class OpenMondayConfiguration
{
    public string? MondayWebApiUrl { get; set; }
    public string? MondayToken { get; set; }    
    
    public OpenMondayConfiguration()
    {
        MondayWebApiUrl = null;
        MondayToken = null;
    }    
}
```

2. App.setings reference

```bash
{
 "OpenMondayConfiguration": {
    "MondayWebApiUrl": "https://api.monday.com/v2/",
    "MondayToken": ""
  }
}
```

3. You can put the token in the app.settings or better as an env variable 
```bash
set OpenMondayConfiguration__MondayToken="yourtoken"
```



