using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces.Services
{
    public class HotelRepository : IHotel
    {

        private readonly AsyncInnDbContext _context;

        public HotelRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Hotel> Create(Hotel hotelBranches)
        {
            _context.Entry(hotelBranches).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return hotelBranches;
        }

        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);
            if (hotel != null)
            {
                _context.Entry(hotel).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<Hotel> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);

            return hotel;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var students = await _context.Hotels.ToListAsync();
            return students;
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotelBranches)
        {
            _context.Entry(hotelBranches).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelBranches;
        }
    }
}
