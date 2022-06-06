using HotelMoonHUB.Application.Services.Contracts;
using HotelMoonHUB.Infrastructure.SvcAgents;

namespace HotelMoonHUB.Application.Services.Implementations
{
    public class HotelLegsService : IHotelLegsService
    {
        public HotelLegsService()
        {
            Providers.ProvidersList.Add(this);
        }

        HotelLegsConnection _hotelLegsConnection = new HotelLegsConnection();

        public async Task<HUBReponse> Search(HUBRequest request , HUBReponse hubReponse)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));

            if(hubReponse == null)
                throw new ArgumentNullException(nameof(hubReponse));

            HotelLegsRequest hotelRequest = RequestHUBtoHotelLegs(request);

            var hotelReponse = await _hotelLegsConnection.Search(hotelRequest);

            if (hotelReponse == null)
                throw new Exception();

            List<Room> hubRooms = hubReponse.rooms.ToList();

            foreach (Result r in hotelReponse.results)
            {
                Room room;

                if (hubRooms.Where(f => f.roomId == r.room).Count() == 0)
                {
                    Room newRoom = new Room()
                    {
                        roomId = r.room,
                        rates = new Rate[0],
                    };

                    hubRooms.Add(newRoom);
                    room = newRoom;
                }

                room = hubRooms.Where(f => f.roomId == r.room).First();

                Rate actualRate = new Rate()
                {
                    mealPlanId = r.meal,
                    isCancellable = r.canCancel,
                    price = r.price
                };

                List<Rate> roomRates = room.rates.ToList();
                roomRates.Add(actualRate);
                room.rates = roomRates.ToArray();
            }

            hubReponse.rooms = hubRooms.ToArray();

            return hubReponse;
        }

        public HotelLegsRequest RequestHUBtoHotelLegs(HUBRequest hubRequest)
        {
            if(hubRequest == null)
                throw new ArgumentNullException(nameof(hubRequest));

            HotelLegsRequest finalRequest = new HotelLegsRequest()
            {
                hotel = hubRequest.hotelId,
                checkInDate = hubRequest.checkIn,
                numberOfNights = NightsCalculator(hubRequest),
                guests = hubRequest.numberOfGuests,
                rooms = hubRequest.numberOfRooms,
                currency = hubRequest.currency,
            };

            return finalRequest;
        }

        public int NightsCalculator(HUBRequest hubRequest)
        {
            if(hubRequest == null)
                throw new ArgumentNullException(nameof(hubRequest));
            
            string[] entry = hubRequest.checkIn.Split("-");
            string[] exit = hubRequest.checkOut.Split("-");

            DateTime checkInDT = new DateTime(int.Parse(entry[0]), int.Parse(entry[1]), int.Parse(entry[2]));
            DateTime checkOutDT = new DateTime(int.Parse(exit[0]), int.Parse(exit[1]), int.Parse(exit[2]));

            TimeSpan daysDiff = checkOutDT - checkInDT;

            int totalNights = daysDiff.Days;

            return totalNights;
        }
    }
}
