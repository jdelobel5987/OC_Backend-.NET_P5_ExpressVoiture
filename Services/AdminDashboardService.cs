using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.ViewModels.Admin;

namespace ExpressVoiture.Services;

public class AdminDashboardService(
    IVehicleRepository vehicleRepository) : IAdminDashboardService
{
    public async Task<AdminDashboardViewModel> GetDashboardAsync(int? vehicleId)
    {
        var vehicles = (await vehicleRepository.GetSelectorOptionsAsync())
                        .ToList();

        var selectedVehicleId =
            vehicleId.HasValue && vehicles.Any(v => v.Id == vehicleId.Value)
                ? vehicleId
                : null;

        return new AdminDashboardViewModel
        {
            SelectedVehicleId = selectedVehicleId,
            Vehicles = [.. vehicles.Select(v => new AdminVehicleOptionViewModel
                {
                    Id = v.Id,
                    DisplayName = $"{v.BrandName} {v.ModelName} - {v.Year}"

                })]
        };
    }
}
