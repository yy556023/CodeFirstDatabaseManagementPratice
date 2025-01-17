### Setup

※本教學使用 MySQL，環境為Windows

選擇一個 要使用的資料庫，執行 docker 指令

SQL Server

```ps1
docker run `
--name mssql `
--env-file mssql/.env `
-p 1433:1433 `
-v mssql_data:/var/opt/mssql/data `
-d mcr.microsoft.com/mssql/server:2022-latest
```

MySQL

```ps1
docker run `
--name mysql `
--env-file mysql/.env `
-p 3306:3306 `
-v mysql_data:/var/lib/mysql `
-d mysql:8.0.35
```

PostgreSQL

```ps1
docker run `
--name postgresql `
--env-file postgresql/.env `
-p 5432:5432 `
-v postgresql_data:/var/lib/postgresql/data `
-d postgres:16.6
```

先加入連線字串進 appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "Default": "Server=localhost;Database={YourDatabaseName}; uid=root; pwd={YOUR_PASSWORD};TreatTinyAsBoolean=false;Charset=utf8mb4;"
  }
}
```

### Basic usage

開始練習 請使用develop分支

main分支為完成後的樣子
