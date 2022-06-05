﻿using HotelMoonHUB.Application.Services;
using HotelMoonHUB.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelMoonHUB.WebAPI.Services.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class HotelMoonController : ControllerBase
    {
        private readonly Service _service;

        public HotelMoonController(Service service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Search(HUBRequest hubRequest)
        {
            var result = await _service.Search(hubRequest);

            if (result == null)
                throw new Exception();

            return Ok(result);
        }

    }
}
