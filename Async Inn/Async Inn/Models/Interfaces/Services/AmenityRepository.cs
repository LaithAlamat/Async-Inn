using Async_Inn.Data;
using Async_Inn.Models.API_s;
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

        public async Task<AmenityDTO> Create(AmenityDTO newAmenityDTO)
        {
            Amenity newAmenity = new Amenity
            {
                ID = newAmenityDTO.ID,
                Name = newAmenityDTO.Name
            };
            _context.Entry(newAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newAmenityDTO;
        }
        public async Task<List<AmenityDTO>> GetAmenities()
        {
            return await _context.Amenities.Select(x => new AmenityDTO
            {
                ID = x.ID,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<AmenityDTO> GetAmenity(int id)
        {

            return await _context.Amenities.Select(x => new AmenityDTO
            {
                ID = x.ID,
                Name = x.Name
            }).FirstOrDefaultAsync(x => x.ID == id);
        }

     
        public async Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO updateAmenityDTO)
        {
            Amenity updateAmenity = new Amenity
            {
                ID = updateAmenityDTO.ID,
                Name = updateAmenityDTO.Name
            };
            _context.Entry(updateAmenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateAmenityDTO;
        }
    }
}
