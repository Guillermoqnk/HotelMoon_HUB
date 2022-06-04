﻿using HotelmoonHUB.Domain.Entities;
using HotelMoonHUB.Application.Services.Contracts;
using HotelMoonHUB.Infrastructure.SvcAgents.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMoonHUB.Application.Services.Implementations
{
    public class HotelLegsService : IHotelLegsService
    {
        private readonly IHotelLegsConnection _hotelLegsConnection;

        public HotelLegsService()
        {
            Providers.ProvidersList.Add(this);
        }

        public HotelLegsService(IHotelLegsConnection hotelLegsConnection)
        {
            _hotelLegsConnection = hotelLegsConnection;
        }

        public async Task<HUBReponse> Search(HUBRequest request , HUBReponse hubReponse)
        {
            HotelLegsRequest hotelRequest = RequestHUBtoHotelLegs(request);

            var hotelReponse = await _hotelLegsConnection.Search(hotelRequest);

            if (hotelReponse == null)
                throw new Exception();

            List<Room> hubRooms = hubReponse.rooms.ToList();

            foreach (Result r in hotelReponse.results)
            {
                Room room = (Room)hubRooms.Where<Room>(f => f.roomId == r.room);

                if (room == null)
                {
                    Room newRoom = new Room()
                    {
                        roomId = r.room,
                    };

                    room = newRoom;
                }

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
