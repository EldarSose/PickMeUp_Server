using PickMeUp.Core.Entities;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Repository;
using PickMeUp.Repository.Interfaces;
using PickMeUp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Service.Services
{
	public class RoleUserService : BaseService<RoleUser, int>, IRoleUserService
	{
		private readonly IRoleUserRepository roleUserRepository;
		private readonly IRolesRepository rolesRepository;

		public RoleUserService(IGenericRepository<RoleUser, int> genericRepository,
			IRoleUserRepository roleUserRepository,
			IRolesRepository rolesRepository) : base(genericRepository)
		{
			this.roleUserRepository = roleUserRepository;
			this.rolesRepository = rolesRepository;
		}

		public RoleUserVM? Add(RoleUserAdd roleUser)
		{
			if (roleUser.roleId == null || roleUser.userId == null)
				return null;

			genericRepository.Add(new RoleUser
			{
				roleId = roleUser.roleId,
				userId = roleUser.userId,
				isDeleted = false
			});

			Roles role = new Roles();

			if(roleUser.roleId.HasValue)
				role = rolesRepository.GetById(roleUser.roleId.Value);

			return new RoleUserVM
			{
				roleName = role.roleName,
			};
		}

		public bool Delete(int id)
		{
			return roleUserRepository.Delete(id);
		}

		public RoleUserVM? Update(RoleUserEdit roleUser)
		{
			if (roleUser.roleId == null || roleUser.userId == null)
				return null;

			RoleUser ru = roleUserRepository.GetAll().FirstOrDefault(x => x.userId == roleUser.userId.Value);

			if (ru == null) return null;

			ru.roleId = roleUser.roleId;

			genericRepository.Update(ru);

			Roles role = new Roles();

			if (roleUser.roleId.HasValue)
				role = rolesRepository.GetById(roleUser.roleId.Value);

			return new RoleUserVM
			{
				roleName = role.roleName,
			};
		}
	}
}
