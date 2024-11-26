using CodeFirstDatabaseManagementPratice.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace CodeFirstDatabaseManagementPratice.HttpApi.Host;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<CodeFirstDatabaseManagementPraticeDbContext>(options =>
        {
            options.UseMySql(Configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(Configuration.GetConnectionString("Default")),
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
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeFirstDatabaseManagementPratice.HttpApi.Host v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
    }
}
