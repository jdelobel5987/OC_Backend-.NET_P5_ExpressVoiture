using ExpressVoiture.Interfaces;
using ExpressVoiture.Models.ViewModels.Admin;

namespace ExpressVoiture.Services;

public class AdminDashboardService(
    IVehicleRepository vehicleRepository,
    IPurchaseRepository purchaseRepository,
    IRepairRepository repairRepository)
    : IAdminDashboardService
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

        var selectedPurchase =
            selectedVehicleId.HasValue
                ? await purchaseRepository.GetByVehicleIdAsync(selectedVehicleId.Value)
                : null;

        var selectedRepairs =
            selectedVehicleId.HasValue
                ? await repairRepository.GetByVehicleIdAsync(selectedVehicleId.Value)
                : [];

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
                },

            PurchaseBlock = new AdminPurchaseBlockViewModel
            {
                VehicleId = selectedVehicleId,

                Purchase = selectedPurchase is null
                    ? null
                    : new AdminPurchaseViewModel
                    {
                        Id = selectedPurchase.Id,
                        VehicleId = selectedPurchase.VehicleId,
                        Price = selectedPurchase.Price,
                        Date = selectedPurchase.Date
                    }
            },

            RepairsBlock = new AdminRepairsBlockViewModel
            {
                VehicleId = selectedVehicleId,

                Repairs = [
                    ..selectedRepairs.Select(repair => new AdminRepairViewModel{
                        Id = repair.Id,
                        VehicleId = repair.vehicleId,
                        RepairTypeId = repair.RepairTypeId,
                        RepairTypeName = repair.RepairTypeName,
                        Price = repair.Price
                    })
                ]
            }
        };
    }
}
