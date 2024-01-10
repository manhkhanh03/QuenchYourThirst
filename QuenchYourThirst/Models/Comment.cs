using QuenchYourThirst.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace QuenchYourThirst.Models
{
    [Table("comments")]
    public class Comment
    {
        public Comment()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;            
        }
        [Key]
        public long id { get; set; }
        public long user_id { get; set; }
        public long? parent_id { get; set; }
        public long product_id { get; set; }
		public string content { get; set; }
		public DateTime? created_at { get; set; }
		public DateTime? updated_at { get; set; }
	}
}
