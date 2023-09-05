if (Test-Path ../publish) { Remove-Item ../publish -Recurse }
if (Test-Path ../publish.zip) { Remove-Item ../publish.zip -Recurse }

dotnet restore ../src/mmmPizza.MoreJeeps.Api
dotnet build  ../src/mmmPizza.MoreJeeps.Api --no-restore --configuration Release
dotnet publish  ../src/mmmPizza.MoreJeeps.Api --no-build --configuration Release --output ../publish
Compress-Archive ../publish/* ../publish.zip -Force

$tfOutput = terraform -chdir="../terraform" output -json | ConvertFrom-Json

az functionapp deployment source config-zip `
    -g $tfOutput.rg.value.name `
    -n $tfOutput.func.value.name `
    --src ../publish.zip

if (Test-Path ../publish) { Remove-Item ../publish -Recurse }
if (Test-Path ../publish.zip) { Remove-Item ../publish.zip -Recurse }