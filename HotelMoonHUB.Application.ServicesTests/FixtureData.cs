using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMoonHUB.Application.ServicesTests1
{
    public class FixtureData
    {
        #region HUBRequest

        public HUBRequest hubRequest = new HUBRequest()
        {
            hotelId = 1,
            checkIn = "2022-2-12",
            checkOut = "2022-2-15",
            numberOfGuests = 3,
            numberOfRooms = 1,
            currency = "EUR"
        };

        #endregion

        #region HUBReponse

        public HUBReponse hubReponse = new HUBReponse();

        public Room room1 = new Room()
        {
            roomId = 1,
        };

        public Room room2 = new Room()
        {
            roomId = 2,
        };

        public Room room3 = new Room()
        {
            roomId = 3,
        };

        public Rate rate1 = new Rate()
        {
            mealPlanId = 1,
            isCancellable = true,
            price = 145
        };

        public Rate rate2 = new Rate()
        {
            mealPlanId = 2,
            isCancellable = true,
            price = 165
        };

        public Rate rate3 = new Rate()
        {
            mealPlanId = 1,
            isCancellable = true,
            price = 155
        };

        public void InitializeHUBReponse()
        {
            var roomList = hubReponse.rooms.ToList();

            roomList.Add(room1);
            roomList.Add(room2);
            roomList.Add(room3);

            hubReponse.rooms = roomList.ToArray();

            var rateList = room1.rates.ToList();

            rateList.Add(rate1);
            rateList.Add(rate2);

            room1.rates = rateList.ToArray();

            rateList = room2.rates.ToList();

            rateList.Add(rate1);

            room2.rates = rateList.ToArray();

            rateList = room3.rates.ToList();

            rateList.Add(rate1);
            rateList.Add(rate2);
            rateList.Add(rate3);

            room3.rates = rateList.ToArray();
        }

        #endregion

        #region HotelLegsRequest

        HotelLegsRequest hotelLegsRequest = new HotelLegsRequest()
        {
            hotel = 1,
            checkInDate = "2022-2-12",
            numberOfNights = 4,
            guests = 3,
            rooms = 1,
            currency = "EUR"
        };

        #endregion

        #region HotelLegsReponse
        public HotelLegsReponse hotelLegsReponse = new HotelLegsReponse();

        public void InitializeHLReponse()
        {
            var resultsList = hotelLegsReponse.results.ToList();

            resultsList.Add(result1);
            resultsList.Add(result1);
            resultsList.Add(result1);

            hotelLegsReponse.results = resultsList.ToArray();
        }

        public Result result1 = new Result()
        {
            room = 1,
            meal = 2,
            canCancel = false,
            price = 155
        };

        public Result result2 = new Result()
        {
            room = 1,
            meal = 1,
            canCancel = true,
            price = 145
        };

        public Result result3 = new Result()
        {
            room = 2,
            meal = 1,
            canCancel = false,
            price = 143
        };

        #endregion
    }
}
