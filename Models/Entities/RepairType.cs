using ExpressVoiture.Interfaces;

namespace ExpressVoiture.Models.Entities
{
    public class RepairType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
