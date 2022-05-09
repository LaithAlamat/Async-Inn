# Hotel Management System

## Problem Domain

Today will the be the beginning of a multi-lab project where you will build out the API server for a Hotel Asset Management system.

## Async Inn

## A project by Laith ALalamat

## Wednesday 13/4/2022

![ERD](./ERD.PNG)

- ### Hotel Table
  The Hotel must have a name and ID and a location and a phone number all of them are primary keys since they must be unique for each location.

The relation between the Hotel and the Hotel Room is One-Many since one hotel can have many hotel rooms.

- ### Hotel Room
  The Hotel Room must have an ID and a number and they are foreign and composite keys since they depend on the location of the hotel and on the type of the Room.

It should also have the hotel ID as a foreign key.

The relation between the hotel room and the room is Many-One since the hotel room can consist of Many rooms

- ### Room
  The Room has an ID and a Name and a Type and all of them are primary keys since each room is unique.

The relation between the Room and Room Amenities is One-Many since many room amenities can be in one room

- ### Room Amenities

The Room Amenities has the Amenities ID as Foreign key as it is unique and a Room ID as a composite key between the Room and the Amenities

The relation between the Room Amenities and the Amenities is Many-One since many amenities can be in a room amenity

- ### Amenities

The Amenities has and ID and Name as a primary key because each one must be unique than the other

## Tuesday 3/5/2022

For today, Lab14 was done and we did tha navigation properties of the project and the routing

we added the capability of adding and deleting an amenity to and from a room in the room controller

POST: api/Rooms/{roomId}/{amenityId}

DELETE: api/Rooms/{roomId}/{amenityId}

We also added the ability to add a room to a hotel or delete a room from a hotel

DELETE: api/HotelRooms/{hotelId}/Rooms/{roomNumber}

PUT: api/HotelRooms/{hotelId}/Rooms/{roomNumber}

## Tuesday 3/5/2022

Lab16 was done and the DTOs were implemented in the project so they can change the output of the controllers so now it can show additional details about the hotel and the rooms in itwith the amineties in each room

### DTO Implementations

    public class HotelDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public List<HotelRoomDTO> Rooms { get; set; }
    }


    public class HotelRoomDTO
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public int RoomID { get; set; }
        public RoomDTO Room { get; set; }
    }

    public class RoomDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Layout { get; set; }
        public List<AmenityDTO> Amenities { get; set; }
    }

    public class AmenityDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

## Identity

ASP.NET Core Identity:

Is an API that supports user interface (UI) login functionality.
Manages users, passwords, profile data, roles, claims, tokens, email confirmation, and more.
Users can create an account with the login information stored in Identity or they can use an external login provider. Supported external login providers include Facebook, Google, Microsoft Account, and Twitter.

Identity is typically configured using a SQL Server database to store user names, passwords, and profile data. Alternatively, another persistent store can be used, for example, Azure Table Storage.

Register:
The user sends a POST request with the registration data(Username, Password, Email, and PhoneNumber), then the program checks for any errors with the input data and if no errors found, it will return that register done, otherwise it will show the error.

Login:
The user sends a POST request with the Login data, then the program checks if there's a user with the Username and password sent, if yes, it will return oK and a message that Login is done, otherwise it will return that the user was not found or the password is wrong.