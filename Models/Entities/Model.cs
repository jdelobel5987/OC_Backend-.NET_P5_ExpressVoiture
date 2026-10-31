using ExpressVoiture.Interfaces;

namespace ExpressVoiture.Models.Entities
{
    public class Model : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Foreign Key
        public int BrandId { get; set; }
        
        // Navigation
        public Brand Brand { get; set; } = null!;
    }
}
