using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMoonHUB.Application.Services
{
    public class DataMapper
    {

        public HotelLegsRequest RequestHUBtoHotelLegs(HUBRequest hubRequest)
        {
            HotelLegsRequest finalRequest = new HotelLegsRequest(){
                hotel = hubRequest.hotelId,
                checkInDate = hubRequest.checkIn,
                numberOfNights = nightsCalculator(hubRequest),
                guests = hubRequest.numberOfGuests,
                rooms = hubRequest.numberOfRooms,
                currency = hubRequest.currency,
            };

            return finalRequest;
        }

        private int nightsCalculator(HUBRequest hubRequest)
        {
            DateTime entrance = Convert.ToDateTime(hubRequest.checkIn);
            DateTime exit = Convert.ToDateTime(hubRequest.checkOut);

            int totalNights = DateTime.Compare(entrance, exit);

            return totalNights;
        }
    }
}
