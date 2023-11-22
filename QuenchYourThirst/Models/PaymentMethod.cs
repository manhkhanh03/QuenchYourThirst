using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
	[Table("payment_methods")]
	public class PaymentMethod
	{
		[Key]
		public long id { get; set; }
		public string name { get; set; }
	}
}
