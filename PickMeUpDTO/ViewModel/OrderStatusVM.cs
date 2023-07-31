using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.ViewModel
{
	public class OrderStatusVM
	{
		public int? id { get; set; }
		public string? orderStatusName { get; set; }
		public string? orderStatusDescription { get; set; }
	}
}
