namespace HotelMoonHUB.Infrastructure.SvcAgents.Contracts
{
    public interface IHotelLegsConnection
    {
        Task<HotelLegsReponse> Search(HotelLegsRequest request);
    }
}
