namespace ExpressVoiture.Models.DTOs.Admin;

public class AdminVehicleListingDto
{
    public int Id { get; init; }
    public int VehicleId { get; init; }
    public DateOnly AvailabilityDate { get; init; }
    public decimal AskingPrice { get; init; }
    public DateOnly? SaleDate { get; init; }
    public decimal? SalePrice { get; init; }
}
