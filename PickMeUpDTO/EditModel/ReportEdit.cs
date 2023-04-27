using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.EditModel
{
	public class ReportEdit
	{
		public int reportId { get; set; }
		public string? reportName { get; set; }
		public string? reportDescription { get; set; }
	}
}
