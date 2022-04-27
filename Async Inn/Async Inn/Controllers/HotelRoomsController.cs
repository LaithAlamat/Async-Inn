﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interfaces;
using Async_Inn.Models.API_s;

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRoom()
        {
            return Ok(await _hotelRoom.GetHotelRooms());
        }

        // GET: api/HotelRooms/5
        [HttpGet("{roomNumber}")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int hotelID, int roomNumber)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoom(hotelID, roomNumber);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            return Ok(hotelRoom);
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int hotelID, int roomNumber, HotelRoomDTO hotelRoom)
        {
            if (hotelID != hotelRoom.HotelID && roomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            var updateHotelRoom = await _hotelRoom.Update(hotelID, roomNumber, hotelRoom);
            return Ok(updateHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom(HotelRoomDTO hotelRoom)
        {
            var newHotelRoom = await _hotelRoom.Create(hotelRoom);

            return Ok(newHotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{roomNumber}")]
        public async Task<IActionResult> DeleteHotelRoom(int hotelID, int roomNumber)
        {
            await _hotelRoom.Delete(hotelID, roomNumber);
            return NoContent();
        }
    }
}
