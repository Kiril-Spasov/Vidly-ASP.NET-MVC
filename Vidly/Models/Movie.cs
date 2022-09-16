using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	public class Movie
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[Required]
		public DateTime ReleaseDate { get; set; }
		[Required]
		public DateTime DateAdded { get; set; }
		[Required]
		public int NumberInStock { get; set; }
		public Genre Genre { get; set; }
		public byte GenreId { get; set; }

	}
}
