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
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Service.Services
{
	public class TaxiDriverCarService : BaseService<TaxiDriverCar, int>, ITaxiDriverCarService
	{
		private readonly ITaxiDriverCarRepository taxiDriverCarRepository;

		public TaxiDriverCarService(IGenericRepository<TaxiDriverCar, int> genericRepository,
			ITaxiDriverCarRepository taxiDriverCarRepository) : base(genericRepository)
		{
			this.taxiDriverCarRepository = taxiDriverCarRepository;
		}

		public TaxiDriverCarVM? Add(CarAdd car)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public TaxiDriverCarVM? Update(CarEdit car)
		{
			throw new NotImplementedException();
		}
	}
}
