using PickMeUp.Core.Entities;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Service.Interfaces
{
	public interface IReportTypeService : IBaseService<ReportType, int>
	{
		bool Delete(int id);
		ReportTypeVM? Add(ReportTypeAdd reportType);
		ReportTypeVM? Update(ReportTypeEdit reportType);
	}
}
