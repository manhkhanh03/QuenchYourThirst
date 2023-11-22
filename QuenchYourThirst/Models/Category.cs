using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
    [Table ("Category")]
    public class Category
    {
        [Key]
        public string?Name { get; set; }
       
        public string? Title { get; set; }
    }
}
