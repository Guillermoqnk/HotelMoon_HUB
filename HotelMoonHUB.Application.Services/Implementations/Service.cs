using HotelMoonHUB.Application.Services.Configuration.FluentValidations;
using HotelMoonHUB.Application.Services.Contracts;
using FluentValidation.Results;

namespace HotelMoonHUB.Application.Services
{
    public class Service : IService
    {
        private readonly IHotelLegsService _hotelLegsService;
        HUBRequestValidator _validator = new HUBRequestValidator(); //Should inyect

        public Service(IHotelLegsService hotelLegsService)
        {
            _hotelLegsService = hotelLegsService;
        }

        public async Task<HUBReponse?> Search(HUBRequest request)
        {

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            ValidationResult validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
                throw new Exception();

            HUBReponse reponse = new HUBReponse()
            {
                rooms = new Room[0],
            };

            foreach(IProviderService service in Providers.ProvidersList)
            {
                reponse = await service.Search(request , reponse);
            }

            return reponse;
        }
    }
}
