using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class Contact
	{
		[Key]
		public int? contactId { get; set; }
		public string? contactName { get; set; }
		public string? contactInfo { get; set; }
		public bool? isDeleted { get; set; }
	}
}
