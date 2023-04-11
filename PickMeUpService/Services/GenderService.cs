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
	public class GenderService : BaseService<Gender, int>, IGenderService
	{
		private readonly IGenderRepository genderRepository;

		public GenderService(IGenericRepository<Gender, int> genericRepository,
			IGenderRepository genderRepository) : base(genericRepository)
		{
			this.genderRepository = genderRepository;
		}

		public GenderVM? Add(CarAdd car)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public GenderVM? Update(CarEdit car)
		{
			throw new NotImplementedException();
		}
	}
}
