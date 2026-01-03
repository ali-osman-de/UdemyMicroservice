
namespace UdemyMicroservice.Shared.Services;

public class IdentityServiceFake : IIdentityService
{
    public Guid UserId => Guid.Parse("dca97489-6fd4-44a7-9a8d-d0da1d1c1ccd");

    public string UserName => "AOD";
}
