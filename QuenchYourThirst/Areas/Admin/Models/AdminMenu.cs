using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace QuenchYourThirst.Areas.Admin.Models
{
	[Table("AdminMenu")]
	public class AdminMenu
	{
		[Key]
		public long id { get; set; }
		public string? name { get; set; }
		public int level { get; set; }
		public int parentLevel { get; set; }
		public int order { get; set; }
		public bool? isActive { get; set; }
		public string? target { get; set; }
		public string? areaName { get; set; }
		public string? controllerName { get; set; }
		public string? actionName { get; set; }
		public string? icon { get; set; }
		public string? idName { get; set; }
	}
}
