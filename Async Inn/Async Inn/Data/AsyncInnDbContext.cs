using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data
{
    public class AsyncInnDbContext: DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }

        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<RoomsAmenities>().HasKey( x =>  new {x.roomId,x.featureId });

            // This calls the base method, but does nothing
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
              new Hotel { ID = 1, Name = "First Hotel", StreetAddress = "First Hotel Address", City = "Madaba", State = "jordan", Country = "Jordan", Phone = "111" },

              new Hotel { ID = 2, Name = "Second Hotel", StreetAddress = "Second Hotel Address", City = "Amman", State = "jordan", Country = "Jordan", Phone = "222" },

              new Hotel { ID = 3, Name = "Third Hotel", StreetAddress = "Third Hotel Address", City = "Irbid", State = "jordan", Country = "Jordan", Phone = "333" }
            );

            modelBuilder.Entity<Room>().HasData(
             new Room { ID = 101, Name = "First Room", Layout = "1"},
             new Room { ID = 102, Name = "Second Room", Layout = "2"},
             new Room { ID = 103, Name = "Third Room", Layout = "3"}
           );


            modelBuilder.Entity<Amenity>().HasData(
             new Amenity { ID = 11, Name = "Coffee Maker"},
             new Amenity { ID = 21, Name = "Ocean View"},
             new Amenity { ID = 31, Name = "Mini Bar"}

           );
            modelBuilder.Entity<HotelRoom>().HasKey(x => new { x.HotelID, x.RoomID });
            modelBuilder.Entity<RoomAmenity>().HasKey(x => new { x.RoomID, x.AmenityID });
        }
    }
}
