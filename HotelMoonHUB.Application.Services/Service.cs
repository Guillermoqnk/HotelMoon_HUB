using HotelMoonHUB.Application.Services.Contracts;
using HotelMoonHUB.Application.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMoonHUB.Application.Services
{
    public class Service
    {
        private readonly IProviderService _hotelLegsService;

        public Service(IProviderService hotelLegsService)
        {
            _hotelLegsService = hotelLegsService;
        }

        public void Search()
        {
            //Llamada a la lista
            //Unificación de respuestas
        }
    }
}
