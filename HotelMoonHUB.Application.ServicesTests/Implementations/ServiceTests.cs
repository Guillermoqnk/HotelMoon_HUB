using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelMoonHUB.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using HotelMoonHUB.Application.Services.Contracts;
using HotelMoonHUB.Infrastructure.SvcAgents.Contracts;
using HotelMoonHUB.Application.Services.Implementations;
using HotelMoonHUB.Infrastructure.SvcAgents;

namespace HotelMoonHUB.Application.Services.ApplicationTests
{
    [TestClass()]
    public class ServiceTests
    {
        [TestMethod()]
        public async Task Integration_Service_SearchMethod_HappyPath()
        {
            HotelLegsService _hotelLegsService = new HotelLegsService();

            var Service = new Service(_hotelLegsService);

            var result = await Service.Search(FixtureData.hubRequest);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HUBReponse));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Integration_Service_SearchMethod_NoHubReponse_BadPath()
        {
            HotelLegsService _hotelLegsService = new HotelLegsService();

            var Service = new Service(_hotelLegsService);

            var result = await Service.Search(FixtureData.hubRequest_Null);

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task Integration_Service_SearchMethod_FluentValidationIsNotValid_NullHotelId_BadPath()
        {
            HotelLegsService _hotelLegsService = new HotelLegsService();

            HUBRequest hubRequest = new HUBRequest()
            {
                checkIn = "2022-2-12",
                checkOut = "2022-2-15",
                numberOfGuests = 3,
                numberOfRooms = 1,
                currency = "EUR"
            };

            var Service = new Service(_hotelLegsService);

            var result = await Service.Search(hubRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task Integration_Service_SearchMethod_FluentValidationIsNotValid_NullCheckIn_BadPath()
        {
            HotelLegsService _hotelLegsService = new HotelLegsService();

            HUBRequest hubRequest = new HUBRequest()
            {
                hotelId = 1,
                checkOut = "2022-2-15",
                numberOfGuests = 3,
                numberOfRooms = 1,
                currency = "EUR"
            };

            var Service = new Service(_hotelLegsService);

            var result = await Service.Search(hubRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task Integration_Service_SearchMethod_FluentValidationIsNotValid_NullCheckOut_BadPath()
        {
            HotelLegsService _hotelLegsService = new HotelLegsService();

            HUBRequest hubRequest = new HUBRequest()
            {
                hotelId = 1,
                checkIn = "2022-2-15",
                numberOfGuests = 3,
                numberOfRooms = 1,
                currency = "EUR"
            };

            var Service = new Service(_hotelLegsService);

            var result = await Service.Search(hubRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task Integration_Service_SearchMethod_FluentValidationIsNotValid_NullNumberOfGuests_BadPath()
        {
            HotelLegsService _hotelLegsService = new HotelLegsService();

            HUBRequest hubRequest = new HUBRequest()
            {
                hotelId = 1,
                checkIn = "2022-2-15",
                checkOut = "2022-2-16",
                numberOfRooms = 1,
                currency = "EUR"
            };

            var Service = new Service(_hotelLegsService);

            var result = await Service.Search(hubRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task Integration_Service_SearchMethod_FluentValidationIsNotValid_NullNumberOfRooms_BadPath()
        {
            HotelLegsService _hotelLegsService = new HotelLegsService();

            HUBRequest hubRequest = new HUBRequest()
            {
                hotelId = 1,
                checkIn = "2022-2-15",
                checkOut = "2022-2-16",
                numberOfGuests = 1,
                currency = "EUR"
            };

            var Service = new Service(_hotelLegsService);

            var result = await Service.Search(hubRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task Integration_Service_SearchMethod_FluentValidationIsNotValid_NullCurrency_BadPath()
        {
            HotelLegsService _hotelLegsService = new HotelLegsService();

            HUBRequest hubRequest = new HUBRequest()
            {
                hotelId = 1,
                checkIn = "2022-2-15",
                checkOut = "2022-2-16",
                numberOfRooms = 1,
                numberOfGuests = 1,
            };

            var Service = new Service(_hotelLegsService);

            var result = await Service.Search(hubRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task Integration_Service_SearchMethod_FluentValidationIsNotValid_NumberOfGuestsUnder0_BadPath()
        {
            HotelLegsService _hotelLegsService = new HotelLegsService();

            HUBRequest hubRequest = new HUBRequest()
            {
                hotelId = 1,
                checkIn = "2022-2-15",
                checkOut = "2022-2-16",
                numberOfRooms = 1,
                numberOfGuests = -1,
                currency = "EUR",
            };

            var Service = new Service(_hotelLegsService);

            var result = await Service.Search(hubRequest);
        }

        [TestMethod]
        public async Task Integration_HotelLegsService_SearchMethod_HappyPath()
        {
            var _hotelLegsService = new HotelLegsService();

            HUBReponse hubReponse = new HUBReponse()
            {
                rooms = new Room[0],
            };

            var result = await _hotelLegsService.Search(FixtureData.hubRequest , hubReponse);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HUBReponse));
            Assert.AreNotEqual(result.rooms.Length , 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Integration_HotelLegsService_SearchMethod_NullRequestParameter_BadPath()
        {
            var _hotelLegsService = new HotelLegsService();

            HUBReponse hubReponse = new HUBReponse()
            {
                rooms = new Room[0],
            };

            var result = await _hotelLegsService.Search(null, hubReponse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Integration_HotelLegsService_SearchMethod_NullReponseParameter_BadPath()
        {
            var _hotelLegsService = new HotelLegsService();

            HUBReponse hubReponse = null;

            var result = await _hotelLegsService.Search(FixtureData.hubRequest, hubReponse);
        }

        [TestMethod]
        public void Integration_HotelLegsService_NightsCalculatorMethod_DaysDiff_HappyPath()
        {
            var _hotelLegsService = new HotelLegsService();

            var result = _hotelLegsService.NightsCalculator(FixtureData.hubRequest);

            Assert.IsNotNull(result);
            Assert.AreEqual(result , 3);
        }

        [TestMethod]
        public void Integration_HotelLegsService_NightsCalculatorMethod_MonthDiff_HappyPath()
        {
            HUBRequest hubRequest = new HUBRequest()
            {
                hotelId = 1,
                checkIn = "2022-1-12",
                checkOut = "2022-2-12",
                numberOfGuests = 3,
                numberOfRooms = 1,
                currency = "EUR"
            };

            var _hotelLegsService = new HotelLegsService();


            var result = _hotelLegsService.NightsCalculator(hubRequest);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, 31);
        }

        [TestMethod]
        public void Integration_HotelLegsService_NightsCalculatorMethod_YearDiff_HappyPath()
        {
            HUBRequest hubRequest = new HUBRequest()
            {
                hotelId = 1,
                checkIn = "2022-1-12",
                checkOut = "2023-1-12",
                numberOfGuests = 3,
                numberOfRooms = 1,
                currency = "EUR"
            };

            var _hotelLegsService = new HotelLegsService();


            var result = _hotelLegsService.NightsCalculator(hubRequest);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, 365);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Integration_HotelLegsService_NightsCalculatorMethod_NullHUBRequest_BadPath()
        {
            var _hotelLegsService = new HotelLegsService();


            var result = _hotelLegsService.NightsCalculator(FixtureData.hubRequest_Null);
        }

        [TestMethod]
        public void Integration_HotelLegsService_RequestHUBtoHotelLegsMethod_HappyPath()
        {
            var _hotelLegsService = new HotelLegsService();

            var result = _hotelLegsService.RequestHUBtoHotelLegs(FixtureData.hubRequest);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HotelLegsRequest));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Integration_HotelLegsService_RequestHUBtoHotelLegsMethod_BadPath()
        {
            var _hotelLegsService = new HotelLegsService();

            var result = _hotelLegsService.RequestHUBtoHotelLegs(FixtureData.hubRequest_Null);
        }
    }
}