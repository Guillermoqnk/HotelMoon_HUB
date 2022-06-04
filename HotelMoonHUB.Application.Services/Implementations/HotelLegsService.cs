using HotelMoonHUB.Application.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMoonHUB.Application.Services.Implementations
{
    public class HotelLegsService : IHotelLegsService
    {
        public HotelLegsService()
        {
            Providers.ProvidersList.Add(this);
        }

        public void sendRequest()
        {
            throw new NotImplementedException();
        }
    }
}
