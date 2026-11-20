using Humanizer;

namespace ExpressVoiture.Models.ViewModels.Admin;

public class AdminVehicleListingViewModel
{
    public int Id { get; init; }
    public int VehicleId { get; init; }
    public DateOnly AvailabilityDate { get; init; }
    public decimal AskingPrice { get; init; }
    public DateOnly? SaleDate { get; init; }
    public decimal? SalePrice { get; init; }
}
