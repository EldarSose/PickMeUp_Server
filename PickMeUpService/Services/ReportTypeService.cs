using PickMeUp.Core.Entities;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Repository;
using PickMeUp.Repository.Interfaces;
using PickMeUp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Service.Services
{
	public class ReportTypeService : BaseService<ReportType, int>, IReportTypeService
	{
		private readonly IReportTypeRepository reportTypeRepository;

		public ReportTypeService(IGenericRepository<ReportType, int> genericRepository,
			IReportTypeRepository reportTypeRepository) : base(genericRepository)
		{
			this.reportTypeRepository = reportTypeRepository;
		}

		public ReportTypeVM? Add(ReportTypeAdd reportType)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public ReportTypeVM? Update(ReportTypeEdit reportType)
		{
			throw new NotImplementedException();
		}
	}
}
