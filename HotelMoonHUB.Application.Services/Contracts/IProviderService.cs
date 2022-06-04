using HotelmoonHUB.Domain.Entities;

namespace HotelMoonHUB.Application.Services.Contracts
{
    public interface IProviderService
    {
        Task<IBaseReponse> Search(HUBRequest request);
        Task<HUBReponse> AddData(HUBReponse hubReponse, IBaseReponse genericReponse);
    }
}
