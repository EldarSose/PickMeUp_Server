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
	public class RolesService : BaseService<Roles, int>, IRolesService
	{
		private readonly IRolesRepository rolesRepository;

		public RolesService(IGenericRepository<Roles, int> genericRepository,
			IRolesRepository rolesRepository) : base(genericRepository)
		{
			this.rolesRepository = rolesRepository;
		}

		public RolesVM? Add(CarAdd car)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public RolesVM? Update(CarEdit car)
		{
			throw new NotImplementedException();
		}
	}
}
