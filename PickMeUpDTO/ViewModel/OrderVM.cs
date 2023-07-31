using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.ViewModel
{
	public class OrderVM
	{
		public int? id { get; set; }
		public string? taxiName { get; set; }
		public string? userFirstName { get; set; }
        public string? userLastName { get; set; }
		public string? driverFirstName { get; set; }
		public string? driverLastName { get; set; }	
		public DateTime? timeUntilArrival { get; set; }
		public string? orderStatusName { get; set; }	

    }
}
