if (Test-Path ../publish_web) { Remove-Item ../publish_web -Recurse }

# Update the configuration to use the hostname built by terraform
$tfOutput = terraform -chdir="../terraform" output -json | ConvertFrom-Json
# (Get-Content ../src/mmmPizza.MoreJeeps.Web/wwwroot/appsettings.json).replace('{{FunctionHost}}', $tfOutput.func.value.default_hostname) | Set-Content ../src/mmmPizza.MoreJeeps.Web/wwwroot/appsettings.json

dotnet restore ../src/mmmPizza.MoreJeeps.Web
dotnet build  ../src/mmmPizza.MoreJeeps.Web --no-restore --configuration Release
dotnet publish  ../src/mmmPizza.MoreJeeps.Web --no-build --configuration Release --output ../publish_web

# (Get-Content ../src/mmmPizza.MoreJeeps.Web/wwwroot/appsettings.json).replace($tfOutput.func.value.default_hostname, '{{FunctionHost}}') | Set-Content ../src/mmmPizza.MoreJeeps.Web/wwwroot/appsettings.json
Remove-Item ../publish_web/wwwroot/appSettings.Development*

swa deploy --output-location ../publish_web/wwwroot --app-name $tfOutput.stapp.value.name --resource-group $tfOutput.rg.value.name --env production

if (Test-Path ../publish_web) { Remove-Item ../publish_web -Recurse }