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
	public class ReportService : BaseService<Report, int>, IReportService
	{
		private readonly IReportRepository reportRepository;
		private readonly IUserRepository userRepository;

		public ReportService(IGenericRepository<Report, int> genericRepository,
			IReportRepository reportRepository,
			IUserRepository userRepository) : base(genericRepository)
		{
			this.reportRepository = reportRepository;
			this.userRepository = userRepository;
		}

		public ReportVM? Add(ReportAdd report)
		{
			if (string.IsNullOrWhiteSpace(report.reportName) || string.IsNullOrWhiteSpace(report.reportDescription) || 
				report.reportTypeId == null || report.userId == null)
				return null;

			genericRepository.Add(new Report
			{
				reportName = report.reportName,
				reportDescription = report.reportDescription,
				reportTypeId = report.reportTypeId,
				userId = report.userId,
				isDeleted = false
			});

			User user = userRepository.GetById((int)report.userId);

			return new ReportVM
			{
				reportName = report.reportName,
				reportDescription = report.reportDescription,
				userFirstName = user.firstName,
				userLastName = user.lastName,
				madeAt = report.madeAt
			};
		}

		public bool Delete(int id)
		{
			return reportRepository.Delete(id);
		}

		public ReportVM? Update(ReportEdit report)
		{
			if (string.IsNullOrWhiteSpace(report.reportName) || string.IsNullOrWhiteSpace(report.reportDescription))
				return null;

			Report r = reportRepository.GetById(report.reportId);

			if (r == null) return null;

			r.reportName = report.reportName;
			r.reportDescription = report.reportDescription;
			genericRepository.Update(r);

			Report report1 = reportRepository.GetById(report.reportId);
			User user = userRepository.GetById((int)report1.userId);

			return new ReportVM
			{
				reportName = report1.reportName,
				reportDescription = report1.reportDescription,
				userFirstName = user.firstName,
				userLastName = user.lastName,
				madeAt = report1.madeAt
			};
		}
	}
}
