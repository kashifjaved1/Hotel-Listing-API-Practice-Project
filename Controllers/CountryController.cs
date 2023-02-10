using AutoMapper;
using HotelListingAPI.Data;
using HotelListingAPI.Models;
using HotelListingAPI.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryDTO createCountry)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var country = _mapper.Map<Country>(createCountry);
                await _uow.Countries.Insert(country);
                await _uow.SaveAsync();

                return CreatedAtRoute("GetCountry", new { id = country.Id }, country);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Source, ex.Message);
            }

            return BadRequest();
        }

        [HttpGet("id", Name = "GetCountry")]
        public async Task<IActionResult> GetCountry(int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var country = await _uow.Countries.GetAsync(q => q.Id == id, new List<string> { "Hotels" });
                if (country != null)
                {
                    var result = _mapper.Map<Country>(country);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Source, ex.Message);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var countries = await _uow.Countries.GetAllAsync();
                var result = _mapper.Map<List<Country>>(countries);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Source, ex.Message);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountry(CountryDTO countryDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var isExist = _uow.Countries.GetAsync(q => q.Id == countryDTO.Id);
                if (isExist != null)
                {
                    var country = _mapper.Map<Country>(isExist);
                    _uow.Countries.Update(country);
                    await _uow.SaveAsync();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Source, ex.Message);
            }

            return BadRequest();
        }
    }
