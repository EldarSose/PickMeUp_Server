using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class RoleUserRepository : GenericRepository<RoleUser, int>, IRoleUserRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public RoleUserRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var RoleUsers = dbContext.RoleUsers.Find(id);
			if (RoleUsers != null)
			{
				RoleUsers.isDeleted = true;
				return true;
			}
			else
				return false;
		}
	}
}
