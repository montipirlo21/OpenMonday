# OpenMonday

**OpenMonday** is an open-source library designed to simplify interactions with the monday.com API, providing tools to manage projects, teams, and workflows intuitively and efficiently. With OpenMonday, developers can easily integrate monday.com into their workflows, automate tasks, and streamline project management processes.

## Features

- **Project Management**: Easily create, update, and manage projects on monday.com.
- **Team Collaboration**: Simplify collaboration by integrating team tasks and workflows into monday.com.
- **API Integration**: Leverage the power of monday.com API to automate and extend functionality.
- **Efficient Workflow Management**: Manage and track workflows with ease.

---

## Installation Guide for developing OpenMonday

To install the necessary tools for working with **OpenMonday**, follow these steps:

### 1. Install StrawberryShake Tools

To install the necessary tool for the project, run the following command in your terminal:

```bash
dotnet tool install --global StrawberryShake.Tools --version 15.0.0-p.15
```

### 2. Set Environment Variable for Monday Token

In order to interact with the monday.com API, you need to set your monday.com API token as an environment variable.

### For Windows:

1. Open a PowerShell or Command Prompt window.
2. Run the following command, replacing `yourtoken` with your actual monday.com API token:

```bash
set OpenMondayConfiguration__MondayToken="yourtoken"
```

3. restart vscode if you don't see the variable. 

### 3. Changelog policy

1. Use the format
    feat: Features
    fix: Bug Fixes
    perf: Performance Improvements
    refactor: Code Refactoring

    feat(documentation): add documentation 

2. Generate changelog after tagging

```bash
git tag -a v1.1.0 -m "Versione 1.1.0"
git-chglog -o CHANGELOG.md
git push origin --tags
```

## Installation Guide for using OpenMonday

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

