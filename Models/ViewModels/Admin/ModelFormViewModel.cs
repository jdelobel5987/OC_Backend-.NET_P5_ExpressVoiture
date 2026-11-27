using System.ComponentModel.DataAnnotations;

namespace ExpressVoiture.Models.ViewModels.Admin;

public class ModelFormViewModel
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Le nom est obligatoire.")]
    [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères.")]
    public string Name { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Veuillez sélectionner une marque.")]
    public int BrandId { get; set; }
    
    public List<BrandOptionViewModel> BrandOptions { get; set; } = [];
}
