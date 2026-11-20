namespace ExpressVoiture.Models.DTOs.Admin;

public class AdminRepairDto
{
    public int Id { get; init; }
    public int vehicleId { get; init; }
    public int RepairTypeId { get; init; }
    public string RepairTypeName { get; init; } = string.Empty;
    public decimal Price { get; init; }
}
