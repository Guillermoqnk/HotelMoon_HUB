using HotelmoonHUB.Application.Dtos.BaseSearchFormatDtos;
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

        public Task<IBaseReponseDto> Search(HUBRequest request)
        {
            throw new NotImplementedException();
        }

        public HotelLegsRequest RequestHUBtoHotelLegs(HUBRequest hubRequest)
        {
            HotelLegsRequest finalRequest = new HotelLegsRequest()
            {
                hotel = hubRequest.hotelId,
                checkInDate = hubRequest.checkIn,
                numberOfNights = nightsCalculator(hubRequest),
                guests = hubRequest.numberOfGuests,
                rooms = hubRequest.numberOfRooms,
                currency = hubRequest.currency,
            };

            return finalRequest;
        }

        public int nightsCalculator(HUBRequest hubRequest)
        {
            string[] entry = hubRequest.checkIn.Split("-");
            string[] exit = hubRequest.checkOut.Split("-");

            int totalNights = Convert.ToInt32(exit[2]) - Convert.ToInt32(entry[2]);

            return totalNights;
        }
    }
}
