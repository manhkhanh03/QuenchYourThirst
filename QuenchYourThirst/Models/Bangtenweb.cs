using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuenchYourThirst.Models
{
    [Table("Bangtenweb")]
    public class Bangtenweb
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
