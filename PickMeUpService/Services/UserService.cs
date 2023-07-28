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
		private readonly ITaxiRepository taxiRepository;
private readonly IGenderRepository genderRepository;
		private readonly IUserAccountRepository userAccountRepository;

		public UserService(IGenericRepository<User, int> genericRepository,
			IUserRepository userRepository,
			ITaxiRepository taxiRepository,
			IGenderRepository genderRepository, 
			IUserAccountRepository userAccountRepository) : base(genericRepository)
		{
			this.userRepository = userRepository;
			this.taxiRepository = taxiRepository;
			this.genderRepository = genderRepository;
			this.userAccountRepository = userAccountRepository;
		}

		public UserVM? Add(UserAdd user)
		{
			if (string.IsNullOrWhiteSpace(user.firstName) || string.IsNullOrWhiteSpace(user.lastName) ||
				user.dateOfBirth == null || user.userAccountID == null || user.genderID == null || 
				string.IsNullOrWhiteSpace(user.phoneNumber))
				return null;

			genericRepository.Add(new User
			{
				firstName = user.firstName,
				lastName = user.lastName,
				dateOfBirth = user.dateOfBirth,
				userAccountID = user.userAccountID,
				taxiCompanyID = user.taxiCompanyID,
				phoneNumber= user.phoneNumber,
				genderID = user.genderID,
			});
			Taxi taxi = new Taxi();

			if(user.taxiCompanyID != null)
				taxi = taxiRepository.GetById((int)user.taxiCompanyID);

			Gender gender = genderRepository.GetById((int)user.genderID);
			UserAccount userAccount = userAccountRepository.GetById((int)user.userAccountID);

			return new UserVM
			{
				firstName = user.firstName,
				lastName = user.lastName,
				dateOfBirth = user.dateOfBirth,
				taxiName = taxi.taxiName,
				gender = gender.description,
				userName = userAccount.email,
				phoneNumber = user.phoneNumber
			};
		}

		public bool Delete(int id)
		{
			return userRepository.Delete(id);
		}

		public UserVM? Update(UserEdit user)
		{
			if (string.IsNullOrWhiteSpace(user.firstName) || string.IsNullOrWhiteSpace(user.lastName) ||
				string.IsNullOrWhiteSpace(user.phoneNumber))
				return null;

			User u = userRepository.GetById(user.userId);
			if (u == null) return null;

			u.firstName= user.firstName;
			u.lastName= user.lastName;
			u.phoneNumber= user.phoneNumber;

			genericRepository.Update(u);
			User user1 = userRepository.GetById(user.userId);
			Taxi taxi = new Taxi();

			if (user1.taxiCompanyID != null)
				taxi = taxiRepository.GetById((int)user1.taxiCompanyID);

			Gender gender = genderRepository.GetById((int)user1.genderID);
			UserAccount userAccount = userAccountRepository.GetById((int)user1.userAccountID);

			return new UserVM
			{
				firstName = user1.firstName,
				lastName = user1.lastName,
				dateOfBirth = user1.dateOfBirth,
				taxiName = taxi.taxiName,
				gender = gender.description,
				userName = userAccount.email,
				phoneNumber = user1.phoneNumber
			};
		}
	}
}
