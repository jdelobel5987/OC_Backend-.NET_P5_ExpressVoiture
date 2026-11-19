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

        var selectedVehicle =
            selectedVehicleId.HasValue
                ? await vehicleRepository.GetAdminDetailsByIdAsync(selectedVehicleId.Value)
                : null;

        return new AdminDashboardViewModel
        {
            SelectedVehicleId = selectedVehicleId,
            Vehicles = [.. vehicles.Select(v => new AdminVehicleOptionViewModel
                {
                    Id = v.Id,
                    DisplayName = $"{v.BrandName} {v.ModelName} - {v.Year}"

                })],
            SelectedVehicle = selectedVehicle is null
                ? null
                : new AdminVehicleDetailsViewModel
                {
                    Id = selectedVehicle.Id,
                    Vin = selectedVehicle.Vin,
                    Year = selectedVehicle.Year,
                    Version = selectedVehicle.Version,
                    BrandName = selectedVehicle.BrandName,
                    ModelName = selectedVehicle.ModelName
                }
        };
    }
}
