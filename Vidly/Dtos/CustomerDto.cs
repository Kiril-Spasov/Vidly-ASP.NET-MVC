using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
	public class CustomerDto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter customer's name.")]
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNewsletter { get; set; }
		public MembershipTypeDto MembershipType { get; set; }
		public byte MembershipTypeId { get; set; }

		[DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
		[DataType(DataType.Date)]
		public DateTime? Birthdate { get; set; }
	}
}
