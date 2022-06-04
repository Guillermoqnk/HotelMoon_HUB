using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMoonHUB.Infrastructure.SvcAgents.Contracts
{
    public interface IHotelLegsConnection
    {
        Task<HotelLegsReponse> Search(HotelLegsRequest request);
    }
}
