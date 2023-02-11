using AutoMapper;
using HotelListingAPI.Data;
using HotelListingAPI.Models;
using HotelListingAPI.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _uow.Hotels.GetAllAsync();
            if(hotels != null)
            {
                _mapper.Map<List<Hotel>>(hotels);
                return Ok(hotels);
            }

            return BadRequest();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            if (id < 1) return BadRequest();

            try
            {
                var hotel = await _uow.Hotels.GetAsync(q => q.Id == id);
                if (hotel != null)
                {
                    _mapper.Map<Hotel>(hotel);
                    return Ok(hotel);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDTO createHotelDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var hotel = _mapper.Map<Hotel>(createHotelDTO);
                await _uow.Hotels.InsertAsync(hotel);
                await _uow.SaveAsync();
                return RedirectToAction("GetAllHotels");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Source, ex.Message);
            }

            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if(id < 1) return BadRequest();

            try
            {
                var hotel = _uow.Hotels.GetAsync(q => q.Id == id);
                if(hotel != null)
                {
                    await _uow.Hotels.DeleteAsync(id);
                    await _uow.SaveAsync();
                    return Ok("Record Deleted Successfully");
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelDTO updateHotelDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var hotel = await _uow.Hotels.GetAsync(q => q.Id == id);
                if(hotel != null)
                {
                    _mapper.Map(updateHotelDTO, hotel);
                    _uow.Hotels.Update(hotel);
                    await _uow.SaveAsync();
                    return RedirectToAction("GetAllHotels");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest();
        }
    }
}
