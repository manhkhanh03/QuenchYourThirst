using QuenchYourThirst.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace QuenchYourThirst.Models
{
    [Table("order")]
    public class Order
    {
        public Order() { 
            created_at = DateTime.ParseExact(Functions.getCurrentDate(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            status_order_id = 6;

		}
        [Key]
        public long id { get; set; }
        public long customer_id { get; set; }
        //public long product_size_flavor_id { get; set; }
        public string shipping_address {  get; set; }
        public int quantity { get; set; }
        public decimal total {  get; set; }
        [ForeignKey("PaymentMethod")]
        public long payment_method_id { get; set; }
        public long payment_status_id { get; set; }
        public long status_order_id {  get; set; }
        public DateTime? created_at { get; set; }
    }
}
