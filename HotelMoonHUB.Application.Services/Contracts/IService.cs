﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMoonHUB.Application.Services.Contracts
{
    public interface IService
    {
        Task<HUBReponse> Search(HUBRequest request);
    }
}
