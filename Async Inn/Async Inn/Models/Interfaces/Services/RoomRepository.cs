﻿using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Room rooms = await _context.Rooms.FindAsync(id);

            return rooms;
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();

            return rooms;
        }
        public async Task<Room> UpdateRoom(int id, Room rooms)
        {
        _context.Entry(rooms).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return rooms;
    }
    
    }
}
