namespace ExpressVoiture.Models.Entities
{
    public class VehicleListing
    {
        public int Id { get; set; }

        // mise en vente
        public DateOnly AvailabilityDate { get; set; }
        public decimal AskingPrice { get; set; }

        // vente effective
        public DateOnly? SaleDate { get; set; }
        public decimal? SalePrice {  get; set; }

        // Foreign Key
        public int VehicleId { get; set; }

        // Navigation
        public Vehicle Vehicle { get; set; } = null!;
    }
}
