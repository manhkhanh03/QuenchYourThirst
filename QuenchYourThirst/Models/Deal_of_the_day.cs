using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
    [Table("Deal_of_the_day")]
    public class Deal_of_the_day
    {
        [Key]
        public int MenuID { get; set; }
        public string? MenuName { get; set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public Decimal Price_discount { get; set; }
        public DateTime? Days{ get; set; }
        public DateTime? Hours { get; set; }    
        public string? Images { get; set; }

    }
}
