namespace ExpressVoiture.Models.ViewModels.Admin;

public class BrandIndexViewModel
{
    public List<BrandListItemViewModel> Brands { get; init; } = [];
    public BrandFormViewModel CreateModel { get; set; } = new();
    public BrandFormViewModel? EditModel { get; set; }
}
