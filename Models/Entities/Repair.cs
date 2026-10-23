namespace ExpressVoiture.Models.Entities
{
    public class Repair
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        // Navigation RepairType
        public int RepairTypeId { get; set; }
        public RepairType RepairType { get; set; } = null!;

        // Foreign Key
        public int VehicleId { get; set; }
        
        // Navigation
        public Vehicle Vehicle { get; set; } = null!;
    }
}
