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

		public GenderVM? Add(GenderAdd gender)
		{
            if (string.IsNullOrWhiteSpace(gender.description))
                return null;
			genericRepository.Add(new Gender
			{
				description=gender.description
			});
			return new GenderVM { description=gender.description };
        }

		public bool Delete(int id)
		{
			return genderRepository.Delete(id);
		}

		public GenderVM? Update(GenderEdit gender)
		{
            if (string.IsNullOrWhiteSpace(gender.description))
                return null;
			genericRepository.Update(new Gender
			{
				genderId = gender.genderId,
				description = gender.description
			});
            return new GenderVM { description = gender.description };
        }
	}
}
