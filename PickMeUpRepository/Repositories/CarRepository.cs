using Microsoft.EntityFrameworkCore;
using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class CarRepository : GenericRepository<Car, int>, ICarRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public CarRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}

		public bool Delete(int id)
		{
			var car = dbContext.Cars.Find(id);
			if(car != null)
			{
				car.isDeleted = true;
				return true;
			}
			else
				return false;
		}
	}
}
