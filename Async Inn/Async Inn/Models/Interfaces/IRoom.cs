using Async_Inn.Models.API_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IRoom
    {
        Task<RoomDTO> Create(RoomDTO room);
        Task<List<RoomDTO>> GetRooms();
        Task<RoomDTO> GetRoom(int id);
        Task<RoomDTO> UpdateRoom(int id, RoomDTO room);
        Task Delete(int id);
        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}

