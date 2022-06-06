using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Moq;
using HotelMoonHUB.Application.Services.Contracts;

namespace HotelMoonHUB.Application.Services.ServiceUnitTests
{
    [TestClass()]
    public class ServiceUnitTests
    {
        private readonly Mock<IHotelLegsService> _hotelLegsService;

        public ServiceUnitTests()
        {
            _hotelLegsService = new Mock<IHotelLegsService>();
        }

        [TestMethod()]
        public async Task Unit_Service_SearchMethod_HappyPath()
        {
            _hotelLegsService.Setup(f => f.Search(FixtureData.hubRequest , It.IsAny<HUBReponse>()))
                .Returns(Task.FromResult(FixtureData.hubReponse));

            Providers.ProvidersList.Add(_hotelLegsService.Object);

            var Service = new Service(_hotelLegsService.Object);

            var result = await Service.Search(FixtureData.hubRequest);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HUBReponse));
            _hotelLegsService.Verify(f => f.Search(FixtureData.hubRequest , It.IsAny<HUBReponse>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Unit_Service_SearchMethod_NullHUBRequest_BadPath()
        {
            var Service = new Service(_hotelLegsService.Object);

            var result = await Service.Search(FixtureData.hubRequest_Null);
        }
    }
}