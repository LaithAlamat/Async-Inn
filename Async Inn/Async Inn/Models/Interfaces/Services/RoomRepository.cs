using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Async_Inn.Models.RoomAmenity;

namespace Async_Inn.Models.Interfaces.Services
{
    public class RoomRepository : IRoom
    {
        private readonly AsyncInnDbContext _context;

        public RoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Room> Create(Room rooms)
        {
            _context.Entry(rooms).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return rooms;
        }

        public async Task Delete(int id)
        {
            Room rooms = await GetRoom(id);
            if (rooms != null)
            {
                _context.Entry(rooms).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.Include(x => x.RoomAmenity)
                                        .ThenInclude(e => e.Amenity)
                                        .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.Include(x => x.RoomAmenity)
                                       .ThenInclude(e => e.Amenity)
                                       .ToListAsync();
        }
        public async Task<Room> UpdateRoom(int id, Room rooms)
        {
        _context.Entry(rooms).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return rooms;
    }
        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new RoomAmenity()
            {
                RoomID = roomId,
                AmenitiesID = amenityId
            };
            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var removeAmentity = _context.RoomsAmenities.FirstOrDefaultAsync(x => x.RoomID == roomId && x.AmenitiesID == amenityId);
            _context.Entry(removeAmentity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
