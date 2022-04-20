using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    interface IAmenity
    {
        Task<Amenity> Create(Amenity amenities);
        Task<List<Amenity>> GetAmenities();
        Task<Amenity> GetAmenitie(int id);
        Task<Amenity> UpdateAmenities(int id, Amenity amenities);
        Task Delete(int id);
    }
}
