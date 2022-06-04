using HotelmoonHUB.Domain.Entities;

namespace HotelMoonHUB.Application.Services.Contracts
{
    public interface IProviderService
    {
        Task<IBaseReponse> Search(HUBRequest request , HUBReponse hubReponse);
    }
}
