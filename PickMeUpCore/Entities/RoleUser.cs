using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class RoleUser
	{
		[ForeignKey(nameof(user))]
		public int? userId { get; set; }
		public User? user { get; set; }
		[ForeignKey(nameof(role))]
		public int? roleId { get; set; }
		public Roles? role { get; set; }
		public bool? isDeleted { get; set; }
	}
}
