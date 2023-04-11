using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class TaxiContact
	{
		[ForeignKey(nameof(taxi))]
		public int? taxiId { get; set; }
		public Taxi? taxi { get; set; }
		[ForeignKey(nameof(contact))]
		public int? contactId { get; set;}
		public Contact? contact { get; set; }
		public bool? isDeleted { get; set; }
	}
}
