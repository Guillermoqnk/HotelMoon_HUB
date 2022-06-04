using HotelMoonHUB.Infrastructure.SvcAgents.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMoonHUB.Infrastructure.SvcAgents
{
    public class HotelLegsConnection : IHotelLegsConnection
    {
        public async Task<HotelLegsReponse> Search(HotelLegsRequest request)
        {
            throw new NotImplementedException(); //Here the request would be sent and we return the reponse
        }
    }
}
