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
	public class TaxiDriverCarService : BaseService<TaxiDriverCar, int>, ITaxiDriverCarService
	{
		private readonly ITaxiDriverCarRepository taxiDriverCarRepository;
		private readonly IUserRepository userRepository;
		private readonly ITaxiRepository taxiRepository;
		private readonly ICarRepository carRepository;

		public TaxiDriverCarService(IGenericRepository<TaxiDriverCar, int> genericRepository,
			ITaxiDriverCarRepository taxiDriverCarRepository,
			IUserRepository userRepository,
			ITaxiRepository taxiRepository,
			ICarRepository carRepository) : base(genericRepository)
		{
			this.taxiDriverCarRepository = taxiDriverCarRepository;
			this.userRepository = userRepository;
			this.taxiRepository = taxiRepository;
			this.carRepository = carRepository;
		}

		public TaxiDriverCarVM? Add(TaxiDriverCarAdd taxiDriverCar)
		{
			if (taxiDriverCar.taxiDriverId == null || taxiDriverCar.carId == null)
				return null;


			genericRepository.Add(new TaxiDriverCar
			{
				carId = taxiDriverCar.carId,
				taxiDriverId = taxiDriverCar.taxiDriverId,
				isDeleted = false,
			});

			Taxi taxi = new Taxi();
			Car car = new Car();
			User user = new User();

			if (taxiDriverCar.taxiDriverId.HasValue)
				user = userRepository.GetById(taxiDriverCar.taxiDriverId.Value);

			if (taxiDriverCar.carId.HasValue)
				car = carRepository.GetById(taxiDriverCar.carId.Value);

			if (car.taxiID.HasValue)
				taxi = taxiRepository.GetById(car.taxiID.Value);

			return new TaxiDriverCarVM
			{
				taxiDriverFirstName = user.firstName,
				taxiDriverLastName = user.lastName,
				carModel = car.carModel,
				plateNumber = car.plateNumber,
				taxiNumber = car.taxiNumber,
				taxiName = taxi.taxiName
			};
		}

		public bool Delete(int id)
		{
			return taxiDriverCarRepository.Delete(id);
		}

		public TaxiDriverCarVM? Update(TaxiDriverCarEdit taxiDriverCar)
		{
			if (taxiDriverCar.taxiDriverId == null || taxiDriverCar.carId == null)
				return null;

			TaxiDriverCar tdc = taxiDriverCarRepository.GetAll().FirstOrDefault(x => x.carId == taxiDriverCar.carId);

			if (tdc == null) return null;

			tdc.taxiDriverId = taxiDriverCar.taxiDriverId;

			genericRepository.Update(tdc);

			Taxi taxi = new Taxi();
			Car car = new Car();
			User user = new User();

			if (taxiDriverCar.taxiDriverId.HasValue)
				user = userRepository.GetById(taxiDriverCar.taxiDriverId.Value);

			if (taxiDriverCar.carId.HasValue)
				car = carRepository.GetById(taxiDriverCar.carId.Value);

			if (car.taxiID.HasValue)
				taxi = taxiRepository.GetById(car.taxiID.Value);

			return new TaxiDriverCarVM
			{
				taxiDriverFirstName = user.firstName,
				taxiDriverLastName = user.lastName,
				carModel = car.carModel,
				plateNumber = car.plateNumber,
				taxiNumber = car.taxiNumber,
				taxiName = taxi.taxiName
			};
		}
	}
}
