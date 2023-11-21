
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
	[Table("Category1")]
	public class Category1
	{
		[Key]
		public string? Name { get; set; }

		public string? Title { get; set; }
	}
}

