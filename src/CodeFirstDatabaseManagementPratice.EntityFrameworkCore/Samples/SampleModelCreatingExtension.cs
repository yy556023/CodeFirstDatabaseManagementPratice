using CodeFirstDatabaseManagementPratice.Domain.Samples;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDatabaseManagementPratice.EntityFrameworkCore.Samples;

public static class SampleModelCreatingExtension
{
    public static void ConfigureSample(this ModelBuilder builder)
    {
        builder.Entity<Sample>(entity =>
        {
            entity.ToTable("Samples", t => t.HasComment("示範資料表"));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName(nameof(Sample.Id)).HasComment("流水號");
            entity.Property(e => e.Name).HasColumnName(nameof(Sample.Name)).HasComment("名稱").HasMaxLength(20).IsRequired();
            entity.Property(e => e.NullableName).HasColumnName(nameof(Sample.NullableName)).HasComment("可Null名稱").HasMaxLength(20).IsRequired();
            entity.Property(e => e.Price).HasColumnName(nameof(Sample.Price)).HasComment("價格").HasColumnType("decimal(10, 2)").HasDefaultValue(0);
            entity.Property(e => e.CreatedAt).HasColumnName(nameof(Sample.CreatedAt)).HasComment("建立時間").IsRequired();
            entity.Property(e => e.UpdatedAt).HasColumnName(nameof(Sample.UpdatedAt)).HasComment("更新時間");

        });

        builder.Entity<Sample>()
            .HasData(data:
            [
                new Sample { Id = 1, Name = "不可為Null欄位", NullableName = null, CreatedAt = DateTime.UtcNow },
            ]);
    }
}
