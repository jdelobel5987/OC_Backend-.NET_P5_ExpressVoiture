using ExpressVoiture.Models.Entities;

namespace ExpressVoiture.Interfaces
{
    public interface IVehicleListingRepository : IRepository<VehicleListing>
    {
        Task<IEnumerable<VehicleListing>> GetAvailableWithDetailsAsync();
    }
}
