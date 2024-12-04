using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using TutorBay.Basket.Api.Dto;
using TutorBay.Shared;

namespace TutorBay.Basket.Api.Feature.GetBasket
{
    public class GetBasketQueryHandler(
        IDistributedCache distributedCache,
        IMapper mapper,
        IBasketService basketService) : IRequestHandler<GetBasketQuery, ServiceResult<BasketDto>>
    {
        public async Task<ServiceResult<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = basketService.GetCacheKey();
            var basketAsString = await basketService.GetBasketFromCacheAsync(cancellationToken);
            if (string.IsNullOrEmpty(basketAsString))
            {
                return ServiceResult<BasketDto>.Error("Basket not found.", System.Net.HttpStatusCode.NotFound);
            }
            var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);
            if (basket == null)
            {
                await distributedCache.RemoveAsync(cacheKey, cancellationToken);
                return ServiceResult<BasketDto>.Error($"There was an error while converting the basket", System.Net.HttpStatusCode.InternalServerError);
            }
            var basketAsDto = mapper.Map<BasketDto>(basket);
            return ServiceResult<BasketDto>.SuccessAsOk(basketAsDto);
        }
    }
}
