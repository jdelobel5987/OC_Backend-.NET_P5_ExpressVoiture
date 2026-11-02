namespace ExpressVoiture.Models.ViewModels
{
    public class VehicleListingItemViewModel
    {
        public int ListingId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
        public int Year { get; set; }
        public string? Version { get; set; }
        public decimal AskingPrice { get; set; }
        public DateOnly AvailabilityDate { get; set; }
    }
}
