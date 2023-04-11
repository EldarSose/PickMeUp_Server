using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class Car
	{
		[Key]
		public int carId { get; set; }
		[ForeignKey(nameof(taxi))]
		public int? taxiID { get; set; }
		public Taxi? taxi { get; set; }
		public string? carModel { get; set; }
		public string? taxiNumber { get; set; }
		public string? plateNumber { get; set; }
		public bool? isDeleted { get; set; }
	}
}
