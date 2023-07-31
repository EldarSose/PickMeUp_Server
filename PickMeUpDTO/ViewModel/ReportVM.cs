using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.ViewModel
{
	public class ReportVM
	{
		public int? id { get; set; }
		public string? reportName { get; set; }
		public string? reportDescription { get; set; }
		public DateTime? madeAt { get; set; }
		public string? userFirstName { get; set; }
		public string? userLastName { get; set; }
		public string? reportAnswer { get; set; }
		public DateTime? answeredAt { get; set; }
		public string? adminFirstName { get; set; }
		public string? adminLastName { get; set; }

	}
}
