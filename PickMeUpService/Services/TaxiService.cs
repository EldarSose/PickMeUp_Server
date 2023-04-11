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
	public class TaxiService : BaseService<Taxi, int>, ITaxiService
	{
		private readonly ITaxiRepository taxiRepository;

		public TaxiService(IGenericRepository<Taxi, int> genericRepository,
			ITaxiRepository taxiRepository) : base(genericRepository)
		{
			this.taxiRepository = taxiRepository;
		}

		public TaxiVM? Add(CarAdd car)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public TaxiVM? Update(CarEdit car)
		{
			throw new NotImplementedException();
		}
	}
}
