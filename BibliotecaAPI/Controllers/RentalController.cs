using BibliotecaAPI.Dto;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var rentals = await _rentalService.GetAllAsync();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var rental = await _rentalService.GetByIdAsync(id);
            if (rental is null)
                return NotFound($"Rental with id {id} not found.");
            return Ok(rental);
        }

        [HttpPost]
        public async Task<IActionResult> RentBookAsync(ToRentDto dto)
        {
            try
            {
                var rental = await _rentalService.RentBookAsync(dto);
                return Ok(rental);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnBookAsync(int id)
        {
            try
            {
                var rental = await _rentalService.ReturnBookAsync(id);
                if (rental is null)
                    return NotFound($"Rental with id {id} not found.");
                return Ok(rental);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _rentalService.DeleteAsync(id);
            if (!deleted)
                return NotFound($"Rental with id {id} not found.");
            return NoContent();
        }
    }
}
