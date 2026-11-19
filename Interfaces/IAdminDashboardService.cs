using ExpressVoiture.Models.ViewModels.Admin;

namespace ExpressVoiture.Interfaces;

public interface IAdminDashboardService
{
    Task <AdminDashboardViewModel> GetDashboardAsync(int? vehicleId);

}
