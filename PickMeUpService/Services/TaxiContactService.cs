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
	public class TaxiContactService : BaseService<TaxiContact, int>, ITaxiContactService
	{
		private readonly ITaxiContactRepository taxiContactRepository;

		public TaxiContactService(IGenericRepository<TaxiContact, int> genericRepository,
			ITaxiContactRepository taxiContactRepository) : base(genericRepository)
		{
			this.taxiContactRepository = taxiContactRepository;
		}

		public TaxiContactVM? Add(TaxiContactAdd taxiContact)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public TaxiContactVM? Update(TaxiContactEdit taxiContact)
		{
			throw new NotImplementedException();
		}
	}
}
