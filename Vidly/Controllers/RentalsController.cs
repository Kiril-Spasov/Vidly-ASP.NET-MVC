using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;
        public RentalsController(ApplicationDbContext context)
        {
            _context = context;
        }


        public ActionResult New()
        {
            return View();
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
