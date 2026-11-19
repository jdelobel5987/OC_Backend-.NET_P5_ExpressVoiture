using System;

namespace ExpressVoiture.Models.ViewModels.Admin;

public class AdminDashboardViewModel
{
    public int? SelectedVehicleId { get; set; }
    public List<AdminVehicleOptionViewModel> Vehicles { get; init; } = [];

}
