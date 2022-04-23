using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces.Services
{
    public class AmenityRepository : IAmenity
    {
        private readonly AsyncInnDbContext _context;

        public AmenityRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Amenity> Create(Amenity amenities)
        {
            _context.Entry(amenities).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return amenities;
        }

        public async Task Delete(int id)
        {
            Amenity amenities = await GetAmenity(id);
            if (amenities != null)
            {
                _context.Entry(amenities).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<Amenity> GetAmenity(int id)
        {
            return await _context.Amenities.Include(x => x.RoomAmenity)
                                         .ThenInclude(x => x.Room)
                                         .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            return await _context.Amenities.Include(x => x.RoomAmenity)
                                       .ThenInclude(x => x.Room)
                                       .ToListAsync();
        }

        public async Task<Amenity> UpdateAmenities(int id, Amenity amenities)
        {
            _context.Entry(amenities).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return amenities;
        }
    }
}
