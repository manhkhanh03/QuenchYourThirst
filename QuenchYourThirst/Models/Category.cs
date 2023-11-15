using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
    [Table ("Category")]
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string? MenuName { get; set; }
        public string? Content { get; set; }
        public string? Title { get; set; }
        public string? Images { get; set; }
    }
}
