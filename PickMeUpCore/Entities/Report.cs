using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class Report
	{
		[Key]
		public int reportId { get; set; }
		public string? reportName { get; set; }
		public string? reportDescription { get; set; }
		public DateTime? madeAt { get; set; }
		[ForeignKey(nameof(reportType))]
		public int? reportTypeId { get; set; }
		public ReportType? reportType { get; set;}
		[ForeignKey(nameof(user))]
		public int? userId { get; set; }
		public User? user { get; set; }
		[ForeignKey(nameof(admin))]
		public int? adminId { get; set; }
		public User? admin { get; set; }
		public string? reportAnswer { get; set; }
		public DateTime? answeredAt { get; set; }
		public bool? isDeleted { get; set; }
	}
}
