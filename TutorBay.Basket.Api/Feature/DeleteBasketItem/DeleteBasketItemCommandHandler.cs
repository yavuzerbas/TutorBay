using MediatR;
using System.Text.Json;
using TutorBay.Shared;

namespace TutorBay.Basket.Api.Feature.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler(IBasketService basketService) : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
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
                return ServiceResult.ErrorAsNotFound();
            }

            var basketItemToBeDeleted = basket.Items.Find(x => x.Id == request.Id);

            if (basketItemToBeDeleted == null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            basket.Items.Remove(basketItemToBeDeleted);

            await basketService.CreateBasketCacheAsync(basket, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
