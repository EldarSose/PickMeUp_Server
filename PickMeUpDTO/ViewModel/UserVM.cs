using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.ViewModel
{
	public class UserVM
	{
		public string? firstName { get; set; }
		public string? lastName { get; set; }
		public string? userName { get; set; }
		public DateTime? dateOfBirth { get; set; }
		public string? gender { get; set; }
		public string? phoneNumber { get; set; }
		public string? taxiName { get; set; }
	}
}
