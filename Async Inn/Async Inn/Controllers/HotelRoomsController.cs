using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _HotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _HotelRoom = hotelRoom;
        }

        // GET: api/HotelRooms/1/Rooms/1
        [HttpGet("{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoomDTO>> GetRoomDetails(int hotelId, int roomNumber)
        {
            var room = await _HotelRoom.RoomDetails(hotelId, roomNumber);
            return Ok(room);
        }

        // GET: api/HotelRooms/1
        [HttpGet("{hotelId}")]
        public async Task<ActionResult<Hotel>> GetHotelRooms(int hotelId)
        {
            var hotelRooms = await _HotelRoom.GetHotelRooms(hotelId);
            return Ok(hotelRooms);
        }
        // PUT: api/HotelRooms/hotelId/Rooms/roomNumber
        [HttpPut("{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoomDTO>> PutHotelRoom(int hotelId, int roomNumber, HotelRoomDTO hotelRoom)
        {
            var newRoom = await _HotelRoom.UpdateRoomDetails(hotelId, roomNumber, hotelRoom);
            return Ok(newRoom);
        }
        // POST: api/HotelRooms/3/1/1
        [HttpPost("{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(int hotelId, HotelRoomDTO room)
        {
            var hotelRoom = await _HotelRoom.AddRoomToHotel(hotelId, room);
            return Ok(hotelRoom);
        }

        // DELETE: api/HotelRooms/1/1
        [HttpDelete("{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> DeleteHotelRoom(int hotelId, int roomNumber)
        {
            await _HotelRoom.DeleteRoomFromHotel(hotelId, roomNumber);
            return NoContent();
        }
    }
}