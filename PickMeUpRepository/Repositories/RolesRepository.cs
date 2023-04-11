using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class RolesRepository : GenericRepository<Roles, int>, IRolesRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public RolesRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var Roles = dbContext.Roles.Find(id);
			if (Roles != null)
			{
				Roles.isDeleted = true;
				return true;
			}
			else
				return false;
		}
	}
}
