namespace ExpressVoiture.Models.DTOs.Admin;

public class AdminPurchaseDto
{
    public int Id { get; init; }
    public int VehicleId { get; init; }
    public decimal Price { get; init; }
    public DateOnly Date { get; init; }
}
