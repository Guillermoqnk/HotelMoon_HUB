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
        public async Task Service_SearchMethod_HappyPath()
        {
            var Service = new Service();

            var result = await Service.Search(FixtureData.hubRequest);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HUBReponse));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Service_SearchMethod_NoHubReponse_BadPath()
        {
            var Service = new Service();

            var result = await Service.Search(FixtureData.hubRequest_Null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task HotelLegsService_SearchMethod_HappyPath()
        {
            var _hotelLegsConnection = new HotelLegsConnection();
            
            var _hotelLegsService = new HotelLegsService(_hotelLegsConnection);

            HUBReponse hubReponse = new HUBReponse()
            {
                rooms = new Room[0],
            };

            var result = await _hotelLegsService.Search(FixtureData.hubRequest , hubReponse);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HUBReponse));
        }
    }
}