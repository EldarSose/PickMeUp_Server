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

		public ReportService(IGenericRepository<Report, int> genericRepository,
			IReportRepository reportRepository) : base(genericRepository)
		{
			this.reportRepository = reportRepository;
		}

		public ReportVM? Add(CarAdd car)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public ReportVM? Update(CarEdit car)
		{
			throw new NotImplementedException();
		}
	}
}
