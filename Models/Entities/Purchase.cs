namespace ExpressVoiture.Models.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateOnly Date { get; set; }

        // Foreign Key
        public int VehicleId { get; set; }
        
        // Navigation
        public Vehicle Vehicle { get; set; } = null!;
    }
}
