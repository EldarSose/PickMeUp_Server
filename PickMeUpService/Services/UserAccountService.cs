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


			UserAccount useracc = userAccountRepository.GetById(userAccount.Id);

			if(useracc == null) return null;


			//ako je poslani username jednak username u bazi i password razlicit od null onda se mijenja password
			if(string.Compare(useracc.email, userAccount.userName) == 1 && !string.IsNullOrWhiteSpace(userAccount.password))
			{
				using var hmac = new HMACSHA512(useracc.passwordSalt);

				var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userAccount.password));

				for (int i = 0; i < computedHash.Length; i++)
				{
					if (computedHash[i] != useracc.passwordHash[i])
						return null;
				}

				using var hmac1 = new HMACSHA512();

				useracc.userAccountId = useracc.userAccountId;
				useracc.email = userAccount.userName;
				useracc.passwordHash = hmac1.ComputeHash(Encoding.UTF8.GetBytes(userAccount.password));
				useracc.passwordSalt = hmac1.Key;

				genericRepository.Update(useracc);
			}

			useracc = userAccountRepository.GetById(userAccount.Id);

			if(useracc == null) return null;

			//ako je poslani username razlicit od usernamea u bazi onda se mijenja username
			if (string.Compare(useracc.email, userAccount.userName) == 0)
			{
				useracc.userAccountId = useracc.userAccountId;
				useracc.email = userAccount.userName;
				useracc.passwordHash = useracc.passwordHash;
				useracc.passwordSalt = useracc.passwordSalt;
				genericRepository.Update(useracc);
			}

			return new UserAccountVM
			{
				userName = userAccount.userName,
			};
		}
	}
}
