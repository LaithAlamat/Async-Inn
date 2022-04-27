using Async_Inn.Models.API_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotelRoom
    {

        Task<HotelRoomDTO> Create(HotelRoomDTO hotelRoomoom);
       
        Task<List<HotelRoomDTO>> GetHotelRooms();
        Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber);
        Task<HotelRoomDTO> Update(int hotelId, int roomNumber, HotelRoomDTO HotelRoomDTO);
        Task Delete(int hotelId, int roomNumber);
    }
}
