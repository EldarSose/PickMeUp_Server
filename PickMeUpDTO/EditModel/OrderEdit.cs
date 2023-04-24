using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.EditModel
{
	public class OrderEdit
	{
		public int orderId { get; set; }
        public int taxiDriverId { get; set; }
        public int orderStatusId { get; set; }
        public DateTime? timeUntilArrival { get; set; }
    }
}
