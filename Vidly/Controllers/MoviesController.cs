﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

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
			// We use Api
			// var movies = _context.Movies.Include(q => q.Genre).ToList();

			if (User.IsInRole(RoleName.CanManageMovies))
			{
				return View("List");
			}
			else
			{
				return View("ReadOnlyList");
			}			
		}

		public IActionResult Details(int id)
		{
			var movie = _context.Movies.Include(q => q.Genre).SingleOrDefault(q => q.Id == id);

			if (movie == null) return NotFound();

			return View(movie);
		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		public IActionResult New()
		{
			var viewModel = new MovieFormViewModel
			{
				Genres = _context.Genre.ToList()
			};

			return View("MovieForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = RoleName.CanManageMovies)]
		public IActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel(movie)
				{
					Genres = _context.Genre.ToList(),
				};

				return View("MovieForm", viewModel);
			}

			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);
			}
			else
			{
				var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
				movieInDb.Name = movie.Name;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
			}

			_context.SaveChanges();

			return RedirectToAction("Index", "Movies");
		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		public IActionResult Edit(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movie is null) return NotFound();

			var viewModel = new MovieFormViewModel(movie)
			{
				Genres = _context.Genre.ToList()
			};

			return View("MovieForm", viewModel);
		}
	}
}
