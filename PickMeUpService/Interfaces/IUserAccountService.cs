using PickMeUp.Core.Entities;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Service.Interfaces
{
	public interface IUserAccountService : IBaseService<UserAccount, int>
	{
		bool Delete(int id);
		UserAccountVM? Add(UserAccountAdd userAccount);
		UserAccountVM? Update(UserAccountEdit userAccount);
	}
}
