using TutorBay.Basket.Api.Dto;
using TutorBay.Shared;

namespace TutorBay.Basket.Api.Feature.GetBasket
{
    public record GetBasketQuery : IRequestByServiceResult<BasketDto>;
}
