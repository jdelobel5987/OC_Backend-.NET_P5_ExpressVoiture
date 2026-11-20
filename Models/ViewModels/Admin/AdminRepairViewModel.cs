namespace ExpressVoiture.Models.ViewModels.Admin;

public class AdminRepairViewModel
{
    public int Id { get; init; }
    public int VehicleId { get; init; }
    public int RepairTypeId { get; init; }
    public string RepairTypeName { get; init; } = string.Empty;
    public decimal Price { get; init; }
}
