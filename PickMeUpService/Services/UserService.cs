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
	public class UserService : BaseService<User, int>, IUserService
	{
		private readonly IUserRepository userRepository;

		public UserService(IGenericRepository<User, int> genericRepository,
			IUserRepository userRepository) : base(genericRepository)
		{
			this.userRepository = userRepository;
		}

		public UserVM? Add(CarAdd car)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public UserVM? Update(CarEdit car)
		{
			throw new NotImplementedException();
		}
	}
}
