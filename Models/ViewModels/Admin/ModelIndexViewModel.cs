namespace ExpressVoiture.Models.ViewModels.Admin;

public class ModelIndexViewModel
{
    public List<ModelListItemViewModel> Models { get; set; } = [];
    public ModelFormViewModel CreateModel { get; set; } = new();
    public ModelFormViewModel? EditModel {get; set; }
}
