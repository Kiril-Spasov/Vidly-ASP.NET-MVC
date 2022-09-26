using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	public class Movie
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[Required]
		[Display(Name="Release Date")]
		[DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
		[DataType(DataType.Date)]
		public DateTime ReleaseDate { get; set; }

		[Required]
		public DateTime DateAdded { get; set; }

		[Required]
        [Range(1, 20)]
		[Display(Name="Number In Stock")]
		public int NumberInStock { get; set; }
		public Genre Genre { get; set; }

		[Required]
		[Display(Name="Genre")]
		public byte GenreId { get; set; }

	}
}
