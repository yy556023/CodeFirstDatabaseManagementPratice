### Setup

※本教學使用 MySQL，環境為Windows

選擇一個 要使用的資料庫，執行 docker 指令

SQL Server

```ps1
docker run `
--name mssql `
# --env-file mssql/.env `
-e ACCEPT_EULA=Y `
-e SA_PASSWORD=cFGqSgHZyhZ4 `
-e MSSQL_PID=Developer `
-p 1433:1433 `
-v mssql_data:/var/opt/mssql/data `
--restart unless-stopped `
-d mcr.microsoft.com/mssql/server:2022-latest
```

Oracle

```ps1
docker run `
--name oracle `
# --env-file oracle/.env `
-e ORACLE_PWD=cFGqSgHZyhZ4 `
-p 1521:1521 `
-v oracle_data:/opt/oracle/oradata `
--restart unless-stopped `
-d container-registry.oracle.com/database/express:21.3.0-xe
```

MySQL

```ps1
docker run `
--name mysql `
# --env-file mysql/.env `
-e MYSQL_ROOT_PASSWORD=cFGqSgHZyhZ4 `
-p 3306:3306 `
-v mysql_data:/var/lib/mysql `
--restart unless-stopped `
-d mysql:8.0.35
```

掛載在本機位置
```ps1
docker run `
--name mysql `
-e MYSQL_ROOT_PASSWORD=cFGqSgHZyhZ4 `
-p 3306:3306 `
-v C:\Users\{Username}\Desktop\MySQL:/var/lib/mysql `
--restart unless-stopped `
-d mysql:8.0.35
```

PostgreSQL

```ps1
docker run `
--name postgresql `
# --env-file postgresql/.env `
-e POSTGRES_PASSWORD=cFGqSgHZyhZ4 `
-p 5432:5432 `
-v postgresql_data:/var/lib/postgresql/data `
--restart unless-stopped `
-d postgres:17.4
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
