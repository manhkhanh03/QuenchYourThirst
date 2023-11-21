using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;


namespace QuenchYourThirst.Models
{
	[Table("Our_products")]
	public class Our_products
	{
		[Key]
        public string? items { get; set; }
        public string? Name { get; set; }
		public string? Title { get; set; }
		public string? Contents { get; set; }
		public string? Images { get; set; }
		public string? Icon { get; set; }
		public string? Money { get; set; }
	}
}
