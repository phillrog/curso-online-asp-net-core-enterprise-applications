dotnet tool install --global dotnet-ef
 dotnet ef database update --project ".\src\services\NSE.Identidade.API\NSE.Identidade.API.csproj"  --startup-project ".\src\services\NSE.Identidade.API\"
 dotnet ef database update --project ".\src\services\NSE.Catalogo.API\NSE.Catalogo.API.csproj"  --startup-project ".\src\services\NSE.Catalogo.API\"
 dotnet ef database update --project ".\src\services\NSE.Clientes.API\NSE.Clientes.API.csproj"  --startup-project ".\src\services\NSE.Clientes.API\"
 dotnet ef database update --project ".\src\services\NSE.Carrinho.API\NSE.Carrinho.API.csproj"  --startup-project ".\src\services\NSE.Carrinho.API\"
 
 dotnet ef database update --project ".\src\services\NSE.Pedido.API\NSE.Pedido.API.csproj"  --startup-project ".\src\services\NSE.Pedido.API\"
 dotnet ef database update --project ".\src\services\NSE.Pagamento.API\NSE.Pagamento.API.csproj"  --startup-project ".\src\services\NSE.Pagamento.API\"
 
