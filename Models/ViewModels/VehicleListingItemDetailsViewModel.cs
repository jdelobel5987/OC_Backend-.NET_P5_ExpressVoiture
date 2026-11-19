namespace ExpressVoiture.Models.ViewModels
{
    public class VehicleListingItemDetailsViewModel
    {
        public int ListingId { get; init; }
        public decimal AskingPrice { get; set; }
        public DateOnly AvailabilityDate { get; set; }
        public int Year { get; set; }
        public string? Version { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public List<string> Repairs { get; set; } = [];
    }
}
