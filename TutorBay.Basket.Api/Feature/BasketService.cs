using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using TutorBay.Basket.Api.Const;
using TutorBay.Shared.Services;

namespace TutorBay.Basket.Api.Feature
{
    public class BasketService(IIdentityService identityService, IDistributedCache distributedCache) : IBasketService
    {
        public string GetCacheKey() => string.Format(BasketConst.BasketCacheKey, identityService.GetUserName);
        public async Task<string?> GetBasketFromCacheAsync(CancellationToken cancellationToken)
        {
            var basketAsString = await distributedCache.GetStringAsync(GetCacheKey(), cancellationToken);
            return basketAsString;
        }
        public async Task CreateBasketCacheAsync(Data.Basket basket, CancellationToken cancellationToken)
        {
            var basketAsString = JsonSerializer.Serialize(basket);
            await distributedCache.SetStringAsync(GetCacheKey(), basketAsString, cancellationToken);
        }
    }
}
