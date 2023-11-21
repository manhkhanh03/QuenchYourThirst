using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
	[Table("status_order")]
	public class StatusOrder
	{
		[Key]
		public long id { get; set; }
		public string name { get; set; }
	}
}
