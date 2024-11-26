namespace CodeFirstDatabaseManagementPratice.Domain.Samples;

public class Sample
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? NullableName { get; set; }
    public decimal Price { get; set; } = 0;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
