namespace ExpressVoiture.Models.DTOs.Admin;

public class VehicleSelectorOptionDto
{
    public int Id { get; init; }
    public string BrandName { get; init; } = string.Empty;
    public string ModelName { get; init; } = string.Empty;
    public int Year { get; init; }
}
