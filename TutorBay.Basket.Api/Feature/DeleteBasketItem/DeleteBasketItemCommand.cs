using TutorBay.Shared;

namespace TutorBay.Basket.Api.Feature.DeleteBasketItem
{
    public record DeleteBasketItemCommand(Guid Id) : IRequestByServiceResult;
}
