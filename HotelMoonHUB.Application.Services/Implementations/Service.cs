using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelMoonHUB.Application.Services.Contracts;
using HotelMoonHUB.Application.Services.Implementations;
using HotelMoonHUB.Infrastructure.SvcAgents;
using HotelMoonHUB.Infrastructure.SvcAgents.Contracts;

namespace HotelMoonHUB.Application.Services
{
    public class Service : IService
    {
        private readonly IHotelLegsService _hotelLegsService;

        public Service(IHotelLegsService hotelLegsService)
        {
            _hotelLegsService = hotelLegsService;
        }

        public async Task<HUBReponse?> Search(HUBRequest request)
        {

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            HUBReponse reponse = new HUBReponse()
            {
                rooms = new Room[0],
            };

            foreach(IProviderService service in Providers.ProvidersList)
            {
                reponse = await service.Search(request , reponse);
            }

            return reponse;
        }
    }
}
