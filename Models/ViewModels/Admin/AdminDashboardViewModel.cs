namespace ExpressVoiture.Models.ViewModels.Admin;

public class AdminDashboardViewModel
{
    public int? SelectedVehicleId { get; set; }
    public List<AdminVehicleOptionViewModel> Vehicles { get; init; } = [];
    public AdminVehicleDetailsViewModel? SelectedVehicle { get; init; }
    public AdminPurchaseBlockViewModel PurchaseBlock { get; init; } = new();
    public AdminRepairsBlockViewModel RepairsBlock { get; init; } = new();
}
