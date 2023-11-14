using QuenchYourThirst.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace QuenchYourThirst.Models
{
    [Table("Cart")]
    public class Cart
    {
        public Cart()
        {
            created_at = DateTime.ParseExact(Functions.getCurrentDate(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }
        [Key]
        public long id { get; set; }
        [ForeignKey("ProductSizeFlavor")]
        public long product_size_flavor_id { get; set; }
        [ForeignKey("User")]
        public long customer_id { get; set; }
        [ForeignKey("StatusProduct")]
        public long status_cart_id { get; set; }
        public int quantity { get; set; }
        public decimal total { get; set; }
        public DateTime? created_at { get; set; }
    }
}
