using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
	[Table("Poster")]
	public class Poster
	{
		[Key]
		public long PotID { get; set; }
		public string? Title { get; set; }
		public string? Contents { get; set; }
		public string? Images { get; set; }
	}
}
