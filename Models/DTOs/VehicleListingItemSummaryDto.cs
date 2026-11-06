namespace ExpressVoiture.Models.DTOs
{
    public class VehicleListingItemSummaryDto
    {
        public int ListingId { get; init; }
        public decimal AskingPrice { get; init; }
        public DateOnly AvailabilityDate { get; init; }
        public int Year { get; init; }
        public string? Version { get; init; }
        public string ModelName { get; init; } = string.Empty;
        public string BrandName { get; init; } = string.Empty;
    }
}
