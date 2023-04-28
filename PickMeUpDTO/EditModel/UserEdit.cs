using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.EditModel
{
	public class UserEdit
	{
		public int? userId { get; set; }
		public string? firstName { get; set; }
		public string? lastName { get; set; }
		public int? genderID { get; set; }
		public string? phoneNumber { get; set; }
	}
}
