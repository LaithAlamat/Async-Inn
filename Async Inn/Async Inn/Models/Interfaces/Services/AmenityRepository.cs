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
            Amenity amenities = await GetAmenitie(id);
            if (amenities != null)
            {
                _context.Entry(amenities).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<Amenity> GetAmenitie(int id)
        {
            Amenity amenities = await _context.Amenities.FindAsync(id);

            return amenities;
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();

            return amenities;
        }

        public async Task<Amenity> UpdateAmenities(int id, Amenity amenities)
        {
            _context.Entry(amenities).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return amenities;
        }
    }
}
