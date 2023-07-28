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
	public class RolesService : BaseService<Roles, int>, IRolesService
	{
		private readonly IRolesRepository rolesRepository;

		public RolesService(IGenericRepository<Roles, int> genericRepository,
			IRolesRepository rolesRepository) : base(genericRepository)
		{
			this.rolesRepository = rolesRepository;
		}

		public RolesVM? Add(RolesAdd role)
		{
			if (string.IsNullOrWhiteSpace(role.roleName) || string.IsNullOrWhiteSpace(role.roleDescription))
				return null;

			genericRepository.Add(new Roles
			{
				roleName = role.roleName,
				roleDescription = role.roleDescription,
				isDeleted = false
			});


			return new RolesVM
			{
				roleName= role.roleName,
				roleDescription= role.roleDescription,
			};
		}

		public bool Delete(int id)
		{
			return rolesRepository.Delete(id);
		}

		public RolesVM? Update(RolesEdit role)
		{
			if (string.IsNullOrWhiteSpace(role.roleName) || string.IsNullOrWhiteSpace(role.roleDescription))
				return null;

			Roles r = rolesRepository.GetById(role.roleId);

			if (r == null) return null;

			r.roleName = role.roleName;
			r.roleDescription = role.roleDescription;

			genericRepository.Update(r);


			return new RolesVM
			{
				roleName = role.roleName,
				roleDescription = role.roleDescription,
			};
		}
	}
}
