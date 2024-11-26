using CodeFirstDatabaseManagementPratice.Domain.Samples;
using CodeFirstDatabaseManagementPratice.EntityFrameworkCore.Samples;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDatabaseManagementPratice.EntityFrameworkCore;

public class CodeFirstDatabaseManagementPraticeDbContext : DbContext
{
    public CodeFirstDatabaseManagementPraticeDbContext(DbContextOptions<CodeFirstDatabaseManagementPraticeDbContext> options)
    : base(options)
    {
    }

    public DbSet<Sample> Samples { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ConfigureSample();
    }
}
