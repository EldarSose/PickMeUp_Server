using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class TaxiRepository : GenericRepository<Taxi, int>, ITaxiRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public TaxiRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var taxi = dbContext.Taxis.Find(id);
			if (taxi != null)
			{
				taxi.isDeleted = true;
				return true;
			}
			else
				return false;
		}
	}
}
