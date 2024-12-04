using Asp.Versioning.Builder;
using TutorBay.Basket.Api.Feature.AddBasketItem;
using TutorBay.Basket.Api.Feature.ApplyDiscount;
using TutorBay.Basket.Api.Feature.DeleteBasketItem;
using TutorBay.Basket.Api.Feature.GetBasket;
using TutorBay.Basket.Api.Feature.RemoveDiscount;

namespace TutorBay.Basket.Api.Feature
{
    public static class BasketEndpointExt
    {
        public static void AddBasketEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiversion}/baskets")
                .WithTags("Baskets")
                .WithApiVersionSet(apiVersionSet)
                .AddBasketItemGroupItemEndpoint()
                .DeleteBasketItemGroupItemEndpoint()
                .GetBasketGroupItemEndpoint()
                .ApplyDiscountCouponGroupItemEndpoint()
                .RemoveDiscountCouponGroupItemEndpoint();
        }
    }
}
