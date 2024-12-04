﻿namespace TutorBay.Shared.Services
{
    public interface IIdentityService
    {
        public Guid GetUserId { get; }
        public string GetUserName { get; }
    }
}
