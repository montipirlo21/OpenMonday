## Installation Guide for developing OpenMonday

To install the necessary tools for working with **OpenMonday**, follow these steps:

### 1. Install StrawberryShake Tools

To install the necessary tool for the project, run the following command in your terminal:

```bash
dotnet tool install --global StrawberryShake.Tools --version 14.2.0
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

### update monday schema ####
rename .graphqlrc.json_old for configuration

```bash
 dotnet graphql update --token $env:OpenMondayConfiguration__MondayToken
 ```

remove barry folder in bin/obj 

### regenerate strawberryshake client  ####
rename .graphqlrc.json_old for configuration

```bash
dotnet graphql generate
 ```

remove barry folder in bin/obj