namespace ExpressVoiture.Models.DTOs.Admin;

public class AdminVehicleDetailsDto
{
    public int Id { get; init; }
    public string? Vin { get; init; }
    public int Year { get; init; }
    public string? Version { get; init; }
    public string BrandName { get; init; } = string.Empty;
    public string ModelName { get; init; } = string.Empty;
}
