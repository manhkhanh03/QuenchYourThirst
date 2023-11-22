using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
	[Table("footer")]
	public class footer
	{
		[Key]
		public string? Help { get; set; }
		public string? Title {  get; set; }
		public string? Menu{ get; set; }
		public string? QYTHIRST {get; set; }
		public string? Icon { get; set; }
		public string? Have_a_Question { get; set; }
		public string? Help2 { get; set; }
		

	}
}
