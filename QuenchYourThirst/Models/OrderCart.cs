using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
	[Table("order_cart")]
	public class OrderCart
	{
		[Key]
		public long id { get; set; }
		public long cart_id { get; set; }
		public long order_id { get; set; }
	}
}
