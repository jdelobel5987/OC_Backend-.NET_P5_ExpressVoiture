namespace ExpressVoiture.Models.ViewModels.Admin;

public class AdminPurchaseViewModel
{
    public int Id { get; init; }
    public int VehicleId { get; init; }
    public decimal Price { get; init; }
    public DateOnly Date { get; init; }
}
