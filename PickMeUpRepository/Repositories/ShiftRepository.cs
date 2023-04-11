using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class ShiftRepository : GenericRepository<Shift, int>, IShiftRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public ShiftRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var Shift = dbContext.Shifts.Find(id);
			if (Shift != null)
			{
				Shift.isDeleted = true;
				return true;
			}
			else
				return false;
		}
	}
}
