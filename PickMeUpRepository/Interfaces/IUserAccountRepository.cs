using PickMeUp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Interfaces
{
	public interface IUserAccountRepository : IGenericRepository<UserAccount, int>
	{
		bool Delete(int id);
		UserAccount AddAcc(UserAccount entity);
	}
}
