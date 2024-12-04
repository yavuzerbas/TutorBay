using MediatR;
using System.Text.Json;
using TutorBay.Basket.Api.Data;
using TutorBay.Shared;

namespace TutorBay.Basket.Api.Feature.AddBasketItem
{
    public class AddBasketItemCommandHandler(IBasketService basketService) : IRequestHandler<AddBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = basketService.GetCacheKey();
            var basketAsString = await basketService.GetBasketFromCacheAsync(cancellationToken);
            var newBasketItem = new BasketItem() { Id = request.CourseId, Name = request.CourseName, ImageUrl = request.ImageUrl, Price = request.CoursePrice, PriceByApplyDiscountRate = null };
            Data.Basket currentBasket;

            if (string.IsNullOrEmpty(basketAsString))
            {
                currentBasket = new Data.Basket() { Items = [newBasketItem] };
            }
            else
            {
                currentBasket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);

                var existingBasketItem = currentBasket.Items.FirstOrDefault(x => x.Id == newBasketItem.Id);
                if (existingBasketItem is not null)
                {
                    currentBasket.Items.Remove(existingBasketItem);
                }

                currentBasket.Items.Add(newBasketItem);
            }
            currentBasket.ApplyAvailableDiscount();

            await basketService.CreateBasketCacheAsync(currentBasket, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
