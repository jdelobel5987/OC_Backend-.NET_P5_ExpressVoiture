namespace ExpressVoiture.Models.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Vin { get; set; }
        public int Year { get; set; }
        public string? Version { get; set; }

        // Foreign Key
        public int ModelId { get; set; }
        
        // Navigations
        public Model Model { get; set; } = null!;

        public ICollection<Repair> Repairs { get; set; } = new List<Repair>();
    }
}
