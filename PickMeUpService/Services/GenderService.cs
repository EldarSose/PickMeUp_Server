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
				description=gender.description,
				isDeleted = false
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

			Gender g = genderRepository.GetById(gender.genderId);

			if(g == null) return null;

			g.description = gender.description;
			genericRepository.Update(g);
            return new GenderVM { description = gender.description };
        }
	}
}
