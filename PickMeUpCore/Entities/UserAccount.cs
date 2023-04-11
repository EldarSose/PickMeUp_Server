using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class UserAccount
	{
		[Key]
		public int userAccountId { get; set; }
		public string? email { get; set; }
		public byte[]? passwordHash { get; set; }
		public byte[]? passwordSalt { get; set; }
		public bool? isDeleted { get; set; }
	}
}
