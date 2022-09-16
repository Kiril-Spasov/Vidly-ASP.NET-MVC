using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;


namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;

		public MoviesController(ApplicationDbContext context)
		{
			_context = context;
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		public IActionResult Index()
		{
			var movies = _context.Movies.Include(q => q.Genre).ToList();
			return View(movies);
		}

		public IActionResult Details(int id)
		{
			var movie = _context.Movies.Include(q => q.Genre).SingleOrDefault(q => q.Id == id);

			if (movie == null) return NotFound();

			return View(movie);
		}

	}
}
