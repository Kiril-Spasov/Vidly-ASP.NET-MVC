using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewRentalsController : ControllerBase
    {
        private ApplicationDbContext _context;
        public NewRentalsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public ActionResult CreateNewRentals(NewRentalsDto newRentalsDto)
        {
            var customer = _context.Customers.Single(c => c.Id == newRentalsDto.CustomerId);

            var movies = _context.Movies.Where(m => newRentalsDto.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
                movie.NumberAvailable--;
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
