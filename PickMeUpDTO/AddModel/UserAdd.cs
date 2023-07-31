using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.AddModel
{
	public class UserAdd
	{
		public string? firstName { get; set; }
		public string? lastName { get; set; }
		public DateTime? dateOfBirth { get; set; }
		public int? genderID { get; set; }
		public string? phoneNumber { get; set; }
		public int? taxiCompanyID { get; set; }
		public string? email { get; set; }
		public string? password { get; set; }
	}
}
