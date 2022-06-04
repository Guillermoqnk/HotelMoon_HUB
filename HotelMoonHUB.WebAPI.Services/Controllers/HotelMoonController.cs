using HotelMoonHUB.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelMoonHUB.WebAPI.Services.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class HotelMoonController : ControllerBase
    {
        private readonly IService _service;

        public HotelMoonController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<HUBReponse> Search(HUBRequest hubRequest)
        {
            var result = await _service.Search(hubRequest);

            if (result == null)
                throw new Exception();

            return result;
        }
    }
}
