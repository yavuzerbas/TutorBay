using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using TutorBay.Shared;

namespace TutorBay.Basket.Api.Feature.ApplyDiscount
{
    public class ApplyDiscountCouponCommandHandler(IDistributedCache cache, IBasketService basketService) : IRequestHandler<ApplyDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
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
                await cache.RemoveAsync(cacheKey, cancellationToken);
                return ServiceResult.Error("Error converting the basket json", System.Net.HttpStatusCode.InternalServerError);
            }
            basket.ApplyNewDiscount(request.couponCode, request.discountRate);

            await basketService.CreateBasketCacheAsync(basket, cancellationToken);

            return ServiceResult.SuccessAsNoContent();

        }
    }
}
