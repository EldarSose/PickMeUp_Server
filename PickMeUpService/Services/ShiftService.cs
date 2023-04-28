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
	public class ShiftService : BaseService<Shift, int>, IShiftService
	{
		private readonly IShiftRepository shiftRepository;

		public ShiftService(IGenericRepository<Shift, int> genericRepository,
			IShiftRepository shiftRepository) : base(genericRepository)
		{
			this.shiftRepository = shiftRepository;
		}

		public ShiftVM? Add(ShiftAdd shift)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public ShiftVM? Update(ShiftEdit shift)
		{
			throw new NotImplementedException();
		}
	}
}
