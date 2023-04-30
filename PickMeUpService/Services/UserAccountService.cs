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
using System.Security.Cryptography;
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

		public UserAccountVM? Add(UserAccountAdd userAccount)
		{
			if (string.IsNullOrWhiteSpace(userAccount.email) || string.IsNullOrWhiteSpace(userAccount.password))
				return null;
			using var hmac = new HMACSHA512();
			genericRepository.Add(new UserAccount
			{
				email = userAccount.email,
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userAccount.password)),
				passwordSalt = hmac.Key,
				isDeleted = false
			});

			return new UserAccountVM 
			{ 
				userName = userAccount.email
			};
		}

		public bool Delete(int id)
		{
			return userAccountRepository.Delete(id);
		}

		public UserAccountVM? Update(UserAccountEdit userAccount)
		{
			//ako je username null vrati null
			if (string.IsNullOrWhiteSpace(userAccount.userName))
				return null;

			
			UserAccount useracc = userAccountRepository.GetAll().FirstOrDefault(x => x.email == userAccount.userName);


			//ako su i username i password razliciti od null onda se mijenja password
			if(!string.IsNullOrWhiteSpace(userAccount.userName) && !string.IsNullOrWhiteSpace(userAccount.password))
			{
				using var hmac = new HMACSHA512(useracc.passwordSalt);

				var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userAccount.password));

				for (int i = 0; i < computedHash.Length; i++)
				{
					if (computedHash[i] != useracc.passwordHash[i])
						return null;
				}

				using var hmac1 = new HMACSHA512();

				genericRepository.Update(new UserAccount
				{
					userAccountId = useracc.userAccountId,
					email = userAccount.userName,
					passwordHash = hmac1.ComputeHash(Encoding.UTF8.GetBytes(userAccount.password)),
					passwordSalt = hmac1.Key,
				});
			}

			//ako je samo username razlicit od null onda se samo mijenja username
			if(!string.IsNullOrWhiteSpace(userAccount.userName) && string.IsNullOrWhiteSpace(userAccount.password))
			{
				genericRepository.Update(new UserAccount
				{
					userAccountId = useracc.userAccountId,
					email= userAccount.userName,
					passwordHash = useracc.passwordHash,
					passwordSalt = useracc.passwordSalt,
				});
			}

			return new UserAccountVM
			{
				userName = userAccount.userName,
			};
		}
	}
}
