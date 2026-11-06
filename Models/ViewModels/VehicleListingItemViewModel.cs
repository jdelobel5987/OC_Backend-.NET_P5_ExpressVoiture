namespace ExpressVoiture.Models.ViewModels
{
    public class VehicleListingItemViewModel
    {
        public int ListingId { get; set; }
        public decimal AskingPrice { get; set; }
        public DateOnly AvailabilityDate { get; set; }
        public int Year { get; set; }
        public string? Version { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
    }
}
