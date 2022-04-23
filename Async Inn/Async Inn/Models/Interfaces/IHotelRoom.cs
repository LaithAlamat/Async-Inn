using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interface
{
    public interface IHotelRoom
    {
        
        Task<HotelRoom> Create(HotelRoom hotelRoomoom);
        
        Task<List<HotelRoom>> GetHotelRooms();
        
        Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);
        
        Task<HotelRoom> Update(int hotelId, int roomNumber, HotelRoom hotelRoom);
        
        Task Delete(int hotelId, int roomNumber);
    }
}