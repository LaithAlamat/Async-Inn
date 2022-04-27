﻿using Async_Inn.Models.API_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotel
    {
        Task<HotelDTO> Create(HotelDTO hotel);
        Task<List<HotelDTO>> GetHotels();
        Task<HotelDTO> GetHotel(int id);
        Task<HotelDTO> UpdateHotel(int id, HotelDTO hotel);
        Task Delete(int id);
    }
}
