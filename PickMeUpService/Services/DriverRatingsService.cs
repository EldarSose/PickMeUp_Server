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
	public class DriverRatingsService : BaseService<DriverRatings, int>, IDriverRatingsService
	{
		private readonly IDriverRatingsRepository driverRatingsRepository;
		private readonly IUserRepository userRepository;

		public DriverRatingsService(IGenericRepository<DriverRatings, int> genericRepository,
			IDriverRatingsRepository driverRatingsRepository,
			IUserRepository userRepository) : base(genericRepository)
		{
			this.driverRatingsRepository = driverRatingsRepository;
			this.userRepository = userRepository;
		}

		public DriverRatingsVM? Add(DriverRatingsAdd ratings)
		{
			if(string.IsNullOrWhiteSpace(ratings.comment) || ratings.rating == null)
				return null;
			genericRepository.Add(new DriverRatings
			{
				userId = ratings.userId,
				rating = ratings.rating,
				comment = ratings.comment,
				driverId = ratings.driverId,
				isDeleted = false
			});

			var driver = userRepository.GetById(ratings.driverId);
			var user = userRepository.GetById(ratings.userId);

			return new DriverRatingsVM
			{
				driverFirstName = driver.firstName,
				driverLastName = driver.lastName,
				userFirstName = user.firstName,
				userLastName = user.lastName,
				rating = ratings.rating,
				comment = ratings.comment
			};
		}

		public bool Delete(int id)
		{
			return driverRatingsRepository.Delete(id);
		}

		public DriverRatingsVM? Update(DriverRatingsEdit ratings)
		{
			if (string.IsNullOrWhiteSpace(ratings.comment) || ratings.rating == null)
				return null;
			genericRepository.Update(new DriverRatings
			{
				driverRatingsId = ratings.driverRatingsId,
				userId = ratings.userId,
				rating = ratings.rating,
				comment = ratings.comment,
				driverId = ratings.driverId,
				isDeleted = false
			});

			var driver = userRepository.GetById(ratings.driverId);
			var user = userRepository.GetById(ratings.userId);

			return new DriverRatingsVM
			{
				driverFirstName = driver.firstName,
				driverLastName = driver.lastName,
				userFirstName = user.firstName,
				userLastName = user.lastName,
				rating = ratings.rating,
				comment = ratings.comment
			};
		}
	}
}
