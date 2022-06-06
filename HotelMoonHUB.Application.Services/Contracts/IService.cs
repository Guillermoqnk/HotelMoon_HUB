namespace HotelMoonHUB.Application.Services.Contracts
{
    public interface IService
    {
        Task<HUBReponse?> Search(HUBRequest request);
    }
}
