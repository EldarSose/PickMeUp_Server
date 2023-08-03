using PickMeUp.Core.Entities;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Repository;
using PickMeUp.Repository.Interfaces;
using PickMeUp.Repository.Repositories;
using PickMeUp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Service.Services
{
	public class TaxiService : BaseService<Core.Entities.Taxi, int>, ITaxiService
	{
		private readonly ITaxiRepository taxiRepository;
		private readonly IUserRepository userRepository;

		public TaxiService(IGenericRepository<Core.Entities.Taxi, int> genericRepository,
			ITaxiRepository taxiRepository,
			IUserRepository userRepository) : base(genericRepository)
		{
			this.taxiRepository = taxiRepository;
			this.userRepository = userRepository;
		}

		public TaxiVM? Add(TaxiAdd taxi)
		{
			if (taxi.userId == null || taxi.pricePerKilometer == null || taxi.startingPrice == null || 
				string.IsNullOrWhiteSpace(taxi.taxiName) ||string.IsNullOrWhiteSpace(taxi.address))
				return null;


            genericRepository.Add(new Core.Entities.Taxi
			{
				taxiName = taxi.taxiName,
				userId = taxi.userId,
				pricePerKilometer = taxi.pricePerKilometer,
				startingPrice = taxi.startingPrice,
				address = taxi.address,
				isDeleted = false,
			});

			User user = new User();
			if(taxi.userId.HasValue) 
				user = userRepository.GetById(taxi.userId.Value);

			return new TaxiVM
			{
				taxiName = taxi.taxiName,
				startingPrice = taxi.startingPrice,
				address = taxi.address,
				pricePerKilometer = taxi.pricePerKilometer,
				userFirstName = user.firstName,
				userLastName = user.lastName,
			};
		}

		public bool Delete(int id)
		{
			return taxiRepository.Delete(id);
		}

		public TaxiVM? Update(TaxiEdit taxi)
		{
			if (taxi.pricePerKilometer == null || taxi.startingPrice == null || string.IsNullOrWhiteSpace(taxi.address))
				return null;

            Core.Entities.Taxi ta = taxiRepository.GetById(taxi.taxiId);
			if(ta == null) return null;

			ta.pricePerKilometer = taxi.pricePerKilometer;
			ta.startingPrice = taxi.startingPrice;
			ta.address = taxi.address;

			genericRepository.Update(ta);

            Core.Entities.Taxi t = taxiRepository.GetById(taxi.taxiId);


			User user = new User();
			if (t.userId.HasValue)
				user = userRepository.GetById(t.userId.Value);

			return new TaxiVM
			{
				taxiName = t.taxiName,
				startingPrice = taxi.startingPrice,
				address = taxi.address,
				pricePerKilometer = taxi.pricePerKilometer,
				userFirstName = user.firstName,
				userLastName = user.lastName,
			};
		}
	}
}
