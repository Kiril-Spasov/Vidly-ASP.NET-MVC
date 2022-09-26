using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
	public class MovieFormViewModel
	{
		public int? Id { get; set; }

		[Required]
		public string? Name { get; set; }

		[Required]
		[Display(Name = "Release Date")]
		[DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
		[DataType(DataType.Date)]
		public DateTime? ReleaseDate { get; set; }

		[Required]
		[Range(1, 20)]
		[Display(Name = "Number In Stock")]
		public int? NumberInStock { get; set; }

		[Required]
		[Display(Name = "Genre")]
		public byte? GenreId { get; set; }
		public List<Genre> Genres { get; set; }

		public string Title
		{
			get
			{
				if (Id != 0)
					return "Edit Movie";

				return "New Movie";
			}
		}

		public MovieFormViewModel()
		{
			Id = 0;
		}

		public MovieFormViewModel(Movie movie)
		{
			Id = movie.Id;
			Name = movie.Name;
			ReleaseDate = movie.ReleaseDate;
			NumberInStock = movie.NumberInStock;
			GenreId = movie.GenreId;
		}
	}
}
