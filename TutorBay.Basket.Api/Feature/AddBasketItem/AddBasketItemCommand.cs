using TutorBay.Shared;

namespace TutorBay.Basket.Api.Feature.AddBasketItem
{
    public record AddBasketItemCommand(
        Guid CourseId,
        string CourseName,
        decimal CoursePrice,
        string? ImageUrl) : IRequestByServiceResult;
}
