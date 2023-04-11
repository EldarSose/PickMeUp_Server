using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class ReportRepository : GenericRepository<Report, int>, IReportRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public ReportRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var Reports = dbContext.Reports.Find(id);
			if (Reports != null)
			{
				Reports.isDeleted = true;
				return true;
			}
			else
				return false;
		}
	}
}
