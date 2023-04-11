using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class DriverRatingsRepository : GenericRepository<DriverRatings, int>, IDriverRatingsRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public DriverRatingsRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var DriverRatings = dbContext.DriverRatings.Find(id);
			if (DriverRatings != null)
			{
				DriverRatings.isDeleted = true;
				return true;
			}
			else
				return false;
		}
	}
}
