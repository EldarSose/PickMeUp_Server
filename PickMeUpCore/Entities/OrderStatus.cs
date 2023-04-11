using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class OrderStatus
	{
		[Key]
		public int ordedStatusId { get; set; }
		public string? orderStatusName { get; set; }
		public string? orderStatusDescription { get; set;}
		public bool? isDeleted { get; set; }
	}
}
