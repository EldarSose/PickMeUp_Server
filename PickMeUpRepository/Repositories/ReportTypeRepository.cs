using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class ReportTypeRepository : GenericRepository<ReportType, int>, IReportTypeRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public ReportTypeRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var ReportTypes = dbContext.ReportTypes.Find(id);
			if (ReportTypes != null)
			{
				ReportTypes.isDeleted = true;
				dbContext.SaveChanges();
				return true;
			}
			else
				return false;
		}
	}
}
