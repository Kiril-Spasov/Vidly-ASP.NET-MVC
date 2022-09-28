using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
	public class MovieDto
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
		[DataType(DataType.Date)]
		public DateTime ReleaseDate { get; set; }

		public DateTime DateAdded { get; set; }

		[Range(1, 20)]
		public int NumberInStock { get; set; }

		public GenreDto Genre { get; set; }

		[Required]
		public byte GenreId { get; set; }
	}
}
