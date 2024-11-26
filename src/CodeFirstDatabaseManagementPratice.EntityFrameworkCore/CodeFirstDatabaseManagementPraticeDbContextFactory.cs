using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace CodeFirstDatabaseManagementPratice.EntityFrameworkCore;

public class CodeFirstDatabaseManagementPraticeDbContextFactory : IDesignTimeDbContextFactory<CodeFirstDatabaseManagementPraticeDbContext>
{
    public CodeFirstDatabaseManagementPraticeDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../CodeFirstDatabaseManagementPratice.HttpApi.Host"));
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();


        var option = new DbContextOptionsBuilder<CodeFirstDatabaseManagementPraticeDbContext>();
        option.UseMySql(
                    configuration.GetConnectionString("Default"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("Default")),
                    action =>
                    {
                        action.DefaultDataTypeMappings(mapping =>

                            mapping
                            .WithClrBoolean(MySqlBooleanType.Bit1)
                            .WithClrDateTime(MySqlDateTimeType.DateTime)
                            .WithClrDateTimeOffset(MySqlDateTimeType.DateTime)
                            .WithClrTimeOnly(0)
                            .WithClrTimeSpan(MySqlTimeSpanType.Time)
                        );

                        action.EnableStringComparisonTranslations();
                        action.UseNewtonsoftJson();
                    });

        return new CodeFirstDatabaseManagementPraticeDbContext(option.Options);
    }
}
