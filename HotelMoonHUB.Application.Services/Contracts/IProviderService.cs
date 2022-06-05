using HotelmoonHUB.Domain.Entities;

namespace HotelMoonHUB.Application.Services.Contracts
{
    public interface IProviderService
    {
        Task<HUBReponse> Search(HUBRequest request , HUBReponse hubReponse);
    }
}
