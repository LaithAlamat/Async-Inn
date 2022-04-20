using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    interface IHotel
    {
        Task<Hotel> Create(Hotel Hotels);
        Task<List<Hotel>> GetHotels();
        Task<Hotel> GetHotel(int id);
        Task<Hotel> UpdateHotel(int id, Hotel hotelBranches);
        Task Delete(int id);
    }
}
