﻿using PickMeUp.Core.Entities;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Repository;
using PickMeUp.Repository.Interfaces;
using PickMeUp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
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
		private readonly IUserAccountService userAccountService;

		public UserService(IGenericRepository<User, int> genericRepository,
			IUserRepository userRepository,
			ITaxiRepository taxiRepository,
			IGenderRepository genderRepository, 
			IUserAccountRepository userAccountRepository,
			IUserAccountService userAccountService) : base(genericRepository)
		{
			this.userRepository = userRepository;
			this.taxiRepository = taxiRepository;
			this.genderRepository = genderRepository;
			this.userAccountRepository = userAccountRepository;
			this.userAccountService = userAccountService;
		}

		public UserVM? Add(UserAdd user)
		{
			if (string.IsNullOrWhiteSpace(user.firstName) || string.IsNullOrWhiteSpace(user.lastName) ||
				user.dateOfBirth == null || string.IsNullOrWhiteSpace(user.email)|| string.IsNullOrWhiteSpace(user.password)
				|| user.genderID == null || 
				string.IsNullOrWhiteSpace(user.phoneNumber))
				return null;

			UserAccountVM useracc =  userAccountService.Add(new UserAccountAdd { email = user.email, password = user.password });

			genericRepository.Add(new User
			{
				firstName = user.firstName,
				lastName = user.lastName,
				dateOfBirth = user.dateOfBirth,
				userAccountID = useracc.id,
				taxiCompanyID = user.taxiCompanyID,
				phoneNumber= user.phoneNumber,
				genderID = user.genderID,
			});
			Taxi taxi = new Taxi();

			if(user.taxiCompanyID != null)
				taxi = taxiRepository.GetById((int)user.taxiCompanyID);

			Gender gender = genderRepository.GetById((int)user.genderID);

			return new UserVM
			{
				firstName = user.firstName,
				lastName = user.lastName,
				dateOfBirth = user.dateOfBirth,
				taxiName = taxi.taxiName,
				gender = gender.description,
				userName = useracc.userName,
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

		public UserVM? Login(LoginVM user)
		{
			if (user == null) return null;

			int? userAccId = userAccountService.GetUsername(user.UserName);

			if (userAccId == null) return null;

			IEnumerable<User> users = genericRepository.GetAll();

			User? u = users.Where(x => x.userAccountID == userAccId) as User;

			if (u == null) return null;

			Taxi taxi = new Taxi();

			if (u.taxiCompanyID != null)
				taxi = taxiRepository.GetById((int)u.taxiCompanyID);

			Gender gender = genderRepository.GetById((int)u.genderID);

			UserAccount userAccount = userAccountRepository.GetById((int)u.userAccountID);

			return new UserVM
			{
				firstName = u.firstName,
				lastName = u.lastName,
				dateOfBirth = u.dateOfBirth,
				taxiName = taxi.taxiName,
				gender = gender.description,
				userName = userAccount.email,
				phoneNumber = u.phoneNumber
			};
		}
	}
}
