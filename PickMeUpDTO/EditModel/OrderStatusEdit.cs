using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.EditModel
{
	public class OrderStatusEdit
	{
		public int ordedStatusId { get; set; }
		public string? orderStatusName { get; set; }
		public string? orderStatusDescription { get; set; }
	}
}
