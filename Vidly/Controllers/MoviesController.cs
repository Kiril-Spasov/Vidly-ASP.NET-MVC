using Microsoft.AspNetCore.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

	}
}
