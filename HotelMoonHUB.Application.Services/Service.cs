using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelMoonHUB.Application.Services.Contracts;
using HotelMoonHUB.Application.Services.Implementations;

namespace HotelMoonHUB.Application.Services
{
    public class Service
    {
        private readonly IHotelLegsService _hotelLegsService;

        public Service(IHotelLegsService hotelLegsService)
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
