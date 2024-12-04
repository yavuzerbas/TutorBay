namespace TutorBay.Basket.Api.Data
{
    public class BasketItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceByApplyDiscountRate { get; set; }

    }
    /*
     * Guid Id,
        string Name,
        string ImageUrl,
        decimal Price,
        float? DiscountRate
     */
}
