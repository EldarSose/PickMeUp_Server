using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class TaxiDriverCarRepository : GenericRepository<TaxiDriverCar, int>, ITaxiDriverCarRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public TaxiDriverCarRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var taxiDriverCars = dbContext.taxiDriverCars.Find(id);
			if (taxiDriverCars != null)
			{
				taxiDriverCars.isDeleted = true;
				dbContext.SaveChanges();
				return true;
			}
			else
				return false;
		}
	}
}
