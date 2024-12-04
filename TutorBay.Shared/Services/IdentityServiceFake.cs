namespace TutorBay.Shared.Services
{
    public class IdentityServiceFake : IIdentityService
    {
        public Guid GetUserId => Guid.Parse("172e9035-f0b2-4aa7-98c6-3a38d8cafa61");

        public string GetUserName => "YavuzErbas";
    }
}
