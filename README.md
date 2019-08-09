# ambiente-dotnet

API Documentação: https://localhost:5001/swagger/

### Sequência de comandos para gerar o banco
dotnet ef migrations add exemploMigration --context ExemploWebApiContext

dotnet ef database update --context ExemploWebApiContext
