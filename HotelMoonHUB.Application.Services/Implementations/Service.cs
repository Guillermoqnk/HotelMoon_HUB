using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelMoonHUB.Application.Services.Contracts;
using HotelMoonHUB.Application.Services.Implementations;

namespace HotelMoonHUB.Application.Services
{
    public class Service : IService
    {
        public async Task<HUBReponse> Search(HUBRequest request)
        {
            HUBReponse reponse = new HUBReponse();

            foreach(IProviderService service in Providers.ProvidersList)
            {
                reponse = await service.Search(request , reponse);
            }

            return reponse;
        }
    }
}
