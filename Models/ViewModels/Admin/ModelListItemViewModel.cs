namespace ExpressVoiture.Models.ViewModels.Admin;

public class ModelListItemViewModel
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int BrandId { get; init; }
    public string BrandName { get; init; } = string.Empty;
}
