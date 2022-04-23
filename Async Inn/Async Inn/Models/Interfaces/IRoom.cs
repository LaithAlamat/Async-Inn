using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(Room rooms);
        Task<List<Room>> GetRooms();
        Task<Room> GetRoom(int id);
        Task<Room> UpdateRoom(int id, Room rooms);
        Task Delete(int id);

        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}

