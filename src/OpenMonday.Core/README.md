# OpenMonday

**OpenMonday** is an open-source library designed to simplify interactions with the monday.com API, providing tools to manage projects, teams, and workflows intuitively and efficiently. With OpenMonday, developers can easily integrate monday.com into their workflows, automate tasks, and streamline project management processes.

## Features

- **Project Management**: Easily create, update, and manage projects on monday.com.
- **Team Collaboration**: Simplify collaboration by integrating team tasks and workflows into monday.com.
- **API Integration**: Leverage the power of monday.com API to automate and extend functionality.
- **Efficient Workflow Management**: Manage and track workflows with ease.

---
## Installation Guide for using OpenMonday

1. Reference the OpenMonday nuget package
2. In the initialization of the application you can configure the DI Service adding AddOpenMondayServices().
3. AddOpenMondayServices needs the url of the monday api and the monday token. Here a simple example of program.cs file


```bash

var builder = WebApplication.CreateBuilder(args);

// Retrieve the configuration from app.settings or env
builder.Services.Configure<OpenMondayConfiguration>(builder.Configuration.GetSection("OpenMondayConfiguration"));
var openMondayConfiguration = new OpenMondayConfiguration();
builder.Configuration.GetSection("OpenMondayConfiguration").Bind(openMondayConfiguration);

// AddOpenMondayServices into the DI 
builder.Services.AddOpenMondayServices(options =>
{
    options.MondayWebApiUrl = openMondayConfiguration.MondayWebApiUrl;
    options.MondayToken = openMondayConfiguration.MondayToken;
});

// Do other configuration and run the application as you like
var app = builder.Build()
app.Run();

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

