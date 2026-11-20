namespace ExpressVoiture.Models.ViewModels.Admin;

public class AdminRepairsBlockViewModel
{
    public int? VehicleId { get; init; }
    public List<AdminRepairViewModel> Repairs { get; init; } = [];
}
