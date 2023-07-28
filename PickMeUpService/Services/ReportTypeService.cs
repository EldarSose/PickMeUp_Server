using PickMeUp.Core.Entities;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Repository;
using PickMeUp.Repository.Interfaces;
using PickMeUp.Repository.Repositories;
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
			if (string.IsNullOrWhiteSpace(reportType.reportName))
				return null;

			genericRepository.Add(new ReportType
			{
				reportName = reportType.reportName,
				isDeleted = false
			});

			return new ReportTypeVM
			{
				reportName = reportType.reportName
			};
		}

		public bool Delete(int id)
		{
			return reportTypeRepository.Delete(id);
		}

		public ReportTypeVM? Update(ReportTypeEdit reportType)
		{
			if (string.IsNullOrWhiteSpace(reportType.reportName))
				return null;

			ReportType rt = reportTypeRepository.GetById(reportType.reportTypeId);

			if(rt == null) return null;

			rt.reportName = reportType.reportName;

			genericRepository.Update(rt);

			return new ReportTypeVM
			{
				reportName = reportType.reportName
			};
		}
	}
}
