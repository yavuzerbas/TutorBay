using MediatR;
using System.Text.Json;
using TutorBay.Shared;

namespace TutorBay.Basket.Api.Feature.RemoveDiscount
{
    public class RemoveDiscountCouponCommandHandler(
        IBasketService basketService) : IRequestHandler<RemoveDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(RemoveDiscountCouponCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = basketService.GetCacheKey();
            var basketAsString = await basketService.GetBasketFromCacheAsync(cancellationToken);
            if (string.IsNullOrEmpty(basketAsString))
            {
                return ServiceResult.ErrorAsNotFound();
            }

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);
            if (basket == null)
            {
                return ServiceResult.Error("Error converting basket json", System.Net.HttpStatusCode.InternalServerError);
            }
            if (!basket.IsApplyDiscount)
            {
                return ServiceResult.Error("There is no discount applied yet", System.Net.HttpStatusCode.NotFound);
            }

            basket.ClearDiscount();
            await basketService.CreateBasketCacheAsync(basket, cancellationToken);
            return ServiceResult.SuccessAsNoContent();
        }
    }
}
