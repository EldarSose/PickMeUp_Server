using PickMeUp.Core.Entities;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Repository;
using PickMeUp.Repository.Interfaces;
using PickMeUp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Service.Services
{
	public class UserAccountService : BaseService<UserAccount, int>, IUserAccountService
	{
		private readonly IUserAccountRepository userAccountRepository;

		public UserAccountService(IGenericRepository<UserAccount, int> genericRepository,
			IUserAccountRepository userAccountRepository) : base(genericRepository)
		{
			this.userAccountRepository = userAccountRepository;
		}

		public UserAccountVM? Add(CarAdd car)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public UserAccountVM? Update(CarEdit car)
		{
			throw new NotImplementedException();
		}
	}
}
