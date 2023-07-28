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
	public class CarService : BaseService<Car, int>, ICarService
	{
		private readonly ICarRepository carRepository;
		private readonly ITaxiService taxiService;

		public CarService(IGenericRepository<Car, int> genericRepository,
			ICarRepository carRepository,
			ITaxiService taxiService) : base(genericRepository)
		{
			this.carRepository = carRepository;
			this.taxiService = taxiService;
		}

		public CarVM? Add(CarAdd car)
		{
			if (string.IsNullOrWhiteSpace(car.taxiNumber) || string.IsNullOrWhiteSpace(car.plateNumber) || string.IsNullOrWhiteSpace(car.carModel))
				return null;
			genericRepository.Add(new Car
			{
				taxiID = car.taxiId,
				plateNumber= car.plateNumber,
				carModel = car.carModel,
				taxiNumber = car.taxiNumber,
				isDeleted = false
			});

			var taxi = taxiService.GetById(car.taxiId);

			return new CarVM
			{
				plateNumber = car.plateNumber,
				carModel = car.carModel,
				taxiNumber = car.taxiNumber,
				taxiName = taxi.taxiName
			};
		}

		public bool Delete(int id)
		{
			return carRepository.Delete(id);
		}

		public CarVM? Update(CarEdit car)
		{
			if (string.IsNullOrWhiteSpace(car.taxiNumber) || string.IsNullOrWhiteSpace(car.plateNumber) || string.IsNullOrWhiteSpace(car.carModel))
				return null;

			Car c = carRepository.GetById(car.carId);
			if(c == null) return null;

			c.taxiID = car.taxiId;
			c.plateNumber = car.plateNumber;
			c.carModel = car.carModel;
			c.taxiNumber = car.taxiNumber;
			c.isDeleted = false;
			genericRepository.Update(c);

			var taxi = taxiService.GetById(car.taxiId);

			return new CarVM
			{
				plateNumber = car.plateNumber,
				carModel = car.carModel,
				taxiNumber = car.taxiNumber,
				taxiName = taxi.taxiName
			};
		}
	}
}
