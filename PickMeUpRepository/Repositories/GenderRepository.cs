using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class GenderRepository : GenericRepository<Gender, int>, IGenderRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public GenderRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var Genders = dbContext.Genders.Find(id);
			if (Genders != null)
			{
				Genders.isDeleted = true;
				return true;
			}
			else
				return false;
		}
	}
}
