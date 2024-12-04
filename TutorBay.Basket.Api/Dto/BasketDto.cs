using System.Text.Json.Serialization;

namespace TutorBay.Basket.Api.Dto
{
    public class BasketDto(

    )
    {
        public List<BasketItemDto> Items { get; init; }
        public float? DiscountRate { get; init; }
        public string? Coupon { get; init; }

        [JsonIgnore]
        public bool IsApplyDiscount => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);
        public decimal TotalPrice => Items.Sum(x => x.Price);
        public decimal? TotalPriceWithAppliedDiscount =>
            !IsApplyDiscount ? null : Items.Sum(x => x.PriceByApplyDiscountRate);
    }
    /*
     * public float? DiscountRate { get; set; }
        public string? Coupon { get; set; }

        [JsonIgnore]
        public bool IsApplyDiscount => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);
        [JsonIgnore]
        public decimal TotalPrice => Items.Sum(x => x.Price);
        [JsonIgnore]
        public decimal? TotalPriceWithAppliedDiscount =>
            !IsApplyDiscount ? null : Items.Sum(x => x.PriceByApplyDiscountRate);
     */
}
