dotnet tool install --global dotnet-ef
 dotnet ef database update --project ".\src\services\NSE.Identidade.API\NSE.Identidade.API.csproj"  --startup-project ".\src\services\NSE.Identidade.API\"
 dotnet ef database update --project ".\src\services\NSE.Catalogo.API\NSE.Catalogo.API.csproj"  --startup-project ".\src\services\NSE.Catalogo.API\"
