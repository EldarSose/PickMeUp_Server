using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class Order
	{
		[Key]
		public int orderId { get; set; }
		[ForeignKey(nameof(taxi))]
		public int? taxiId { get; set; }
		public Taxi? taxi { get; set; }
		[ForeignKey(nameof(user))]
		public int? userId { get; set; }
		public User? user { get; set; }
		[ForeignKey(nameof(taxiDriver))]
		public int? taxiDriverId { get; set;}
		public User? taxiDriver { get; set; }

		public DateTime? timeUntilArrival { get; set; }
		[ForeignKey(nameof(orderStatus))]
		public int? orderStatusId { get; set; }
		public OrderStatus? orderStatus { get; set;}
		public bool? isDeleted { get; set; }
	}
}
