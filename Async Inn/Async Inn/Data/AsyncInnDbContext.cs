using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Async_Inn.Models.RoomAmenity;

namespace Async_Inn.Data
{
    public class AsyncInnDbContext: DbContext
    {
            public DbSet<Hotel> Hotels { get; set; }
            public DbSet<Room> Rooms { get; set; }
            public DbSet<Amenity> Amenities { get; set; }

            public DbSet<HotelRoom> HotelRoom { get; set; }
            public DbSet<RoomAmenity> RoomsAmenities { get; set; }
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<RoomsAmenities>().HasKey( x =>  new {x.roomId,x.featureId });

            // This calls the base method, but does nothing
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
              new Hotel { ID = 1, Name = "First Hotel", StreetAddress = "First Hotel Address", City = "Madaba", State = "jordan", Country = "Jordan", PhoneNumber = "111" },

              new Hotel { ID = 2, Name = "Second Hotel", StreetAddress = "Second Hotel Address", City = "Amman", State = "jordan", Country = "Jordan", PhoneNumber = "222" },

              new Hotel { ID = 3, Name = "Third Hotel", StreetAddress = "Third Hotel Address", City = "Irbid", State = "jordan", Country = "Jordan", PhoneNumber = "333" }
            );

            modelBuilder.Entity<Room>().HasData(
             new Room { ID = 101, Name = "First Room", Layout = 1},
             new Room { ID = 102, Name = "Second Room", Layout = 2},
             new Room { ID = 103, Name = "Third Room", Layout = 3}
           );


            modelBuilder.Entity<Amenity>().HasData(
             new Amenity { ID = 11, Name = "Coffee Maker"},
             new Amenity { ID = 21, Name = "Ocean View"},
             new Amenity { ID = 31, Name = "Mini Bar"}

           );
            modelBuilder.Entity<RoomAmenity>()
                .HasKey(RoomAmenity => new { RoomAmenity.RoomID, RoomAmenity.AmenitiesID });

            modelBuilder.Entity<HotelRoom>()
                        .HasKey(HotelRoomNumber => new { HotelRoomNumber.HotelID, HotelRoomNumber.RoomNumber });
        }
    }
}
