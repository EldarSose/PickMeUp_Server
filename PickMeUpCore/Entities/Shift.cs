using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class Shift
	{
		[Key]
		public int shiftId { get; set; }
		public DateTime? startTime { get; set; }
		public DateTime? endTime { get; set; }
		[ForeignKey(nameof(taxiDriver))]
		public int? taxiDriverId { get; set; }
		public User? taxiDriver { get; set; }
		[ForeignKey(nameof(taxiCompany))]
		public int? taxiCompanyId { get; set; }
		public Taxi? taxiCompany { get; set; }
		public bool? tookABreak { get; set; }
		public bool? isDeleted { get; set; }
	}
}
