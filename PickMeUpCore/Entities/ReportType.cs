using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class ReportType
	{
		[Key]
		public int reportTypeId { get; set; }
		public string? reportName { get; set; }
		public bool? isDeleted { get; set; }
	}
}
