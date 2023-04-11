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
	public class RoleUserService : BaseService<RoleUser, int>, IRoleUserService
	{
		private readonly IRoleUserRepository roleUserRepository;

		public RoleUserService(IGenericRepository<RoleUser, int> genericRepository,
			IRoleUserRepository roleUserRepository) : base(genericRepository)
		{
			this.roleUserRepository = roleUserRepository;
		}

		public RoleUserVM? Add(CarAdd car)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public RoleUserVM? Update(CarEdit car)
		{
			throw new NotImplementedException();
		}
	}
}
