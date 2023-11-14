using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuenchYourThirst.Areas.Admin.Models
{
	[Table("roles")]
	public class Role
	{
		[Key]
		public long id { get; set; }
		public string name { get; set; }
	}
}
