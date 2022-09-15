using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;


namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext _context;
		public CustomersController(ApplicationDbContext context)
		{
			_context = context;
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public IActionResult Index()
		{
			var customers = _context.Customers.Include(c => c.MembershipType).ToList();

			return View(customers);
		}

		public IActionResult Details(int id)
		{
			var customer = _context.Customers.SingleOrDefault(q => q.Id == id);

			return View(customer);
		}
	}
}
