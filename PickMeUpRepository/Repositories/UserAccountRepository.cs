using Microsoft.EntityFrameworkCore;
using PickMeUp.Core.Entities;
using PickMeUp.DTO.AddModel;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class UserAccountRepository : GenericRepository<UserAccount, int>, IUserAccountRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public UserAccountRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var UserAccounts = dbContext.UserAccounts.Find(id);
			if (UserAccounts != null)
			{
				UserAccounts.isDeleted = true;
				dbContext.SaveChanges();
				return true;
			}
			else
				return false;
		}
		public UserAccount AddAcc(UserAccount entity)
		{
			dbContext.UserAccounts.Add(entity);
			dbContext.SaveChanges();
			return dbContext.UserAccounts.AsEnumerable().First(x => string.Compare(x.email, entity.email) == 1);
		}
	}
}
