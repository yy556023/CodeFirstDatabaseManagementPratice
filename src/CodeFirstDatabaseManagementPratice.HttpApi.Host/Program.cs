namespace CodeFirstDatabaseManagementPratice.HttpApi.Host;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Environment.WebRootPath = Environment.CurrentDirectory;

            var startup = new Startup(builder.Configuration);

            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            startup.Configure(app);

            await app.RunAsync();

            return 0;
        }
        catch
        {
            return 1;
        }
    }
}
