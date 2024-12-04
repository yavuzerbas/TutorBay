namespace TutorBay.Basket.Api.Feature
{
    public interface IBasketService
    {
        public string GetCacheKey();
        public Task<string?> GetBasketFromCacheAsync(CancellationToken cancellationToken);
        public Task CreateBasketCacheAsync(Data.Basket basket, CancellationToken cancellationToken);
    }
}
