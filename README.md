# OpenMonday
An open-source library designed to simplify interactions with the monday.com API, providing tools to manage projects, teams, and workflows intuitively and efficiently



// Install tool guide
dotnet tool install --global StrawberryShake.Tools --version 15.0.0-p.15

// Set enviroment variable 

OpenMondayConfiguration__MondayToken


set OpenMondayConfiguration__MondayToken="yourtoken"

restart vscode


changelog

git tag -a v1.1.0 -m "Versione 1.1.0"
git-chglog -o CHANGELOG.md
git push origin --tags
