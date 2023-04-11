using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class User
	{
		[Key]
		public int userId { get; set; }
		public string? firstName { get; set; }
		public string? lastName { get; set; }
		[ForeignKey(nameof(userAccount))]
		public int? userAccountID { get; set; }
		public UserAccount? userAccount { get; set; }
		public DateTime? dateOfBirth { get; set; }
		[ForeignKey(nameof(gender))]
		public int? genderID { get;set; }
		public Gender? gender { get; set; }
		public string? phoneNumber { get; set; }
		[ForeignKey(nameof(taxiCompany))]
		public int? taxiCompanyID { get; set; }
		public Taxi? taxiCompany { get; set; }
		public bool? isDeleted { get; set; }

	}
}
