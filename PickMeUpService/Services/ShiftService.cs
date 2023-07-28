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
	public class ShiftService : BaseService<Shift, int>, IShiftService
	{
		private readonly IShiftRepository shiftRepository;
		private readonly ITaxiRepository taxiRepository;
		private readonly IUserRepository userRepository;

		public ShiftService(IGenericRepository<Shift, int> genericRepository,
			IShiftRepository shiftRepository,
			ITaxiRepository taxiRepository,
			IUserRepository userRepository) : base(genericRepository)
		{
			this.shiftRepository = shiftRepository;
			this.taxiRepository = taxiRepository;
			this.userRepository = userRepository;
		}

		public ShiftVM? Add(ShiftAdd shift)
		{
			if (shift.startTime == null || shift.endTime == null || shift.taxiDriverId == null || shift.taxiCompanyId == null)
				return null;


			genericRepository.Add(new Shift
			{
				startTime = shift.startTime,
				endTime = shift.endTime,
				taxiDriverId = shift.taxiDriverId,
				taxiCompanyId = shift.taxiCompanyId,
				tookABreak = false,
				isDeleted= false,
			});

			Shift smjena = new Shift
			{
				startTime = shift.startTime,
				endTime = shift.endTime,
				taxiDriverId = shift.taxiDriverId,
				taxiCompanyId = shift.taxiCompanyId,
				tookABreak = false,
				isDeleted = false,
			};
			Taxi taxi = new Taxi();
			User user = new User();

			if (shift.taxiCompanyId.HasValue)
				taxi = taxiRepository.GetById(shift.taxiCompanyId.Value);

			if (shift.taxiDriverId.HasValue)
				user = userRepository.GetById(shift.taxiDriverId.Value);

			return new ShiftVM
			{
				startTime = shift.startTime,
				endTime = shift.endTime,
				taxiName = taxi.taxiName,
				tookABreak = smjena.tookABreak,
				taxiDriverFirstName = user.firstName,
				taxiDriverLastName = user.lastName,
			};
		}

		public bool Delete(int id)
		{
			return shiftRepository.Delete(id);
		}

		public ShiftVM? Update(ShiftEdit shift)
		{
			if (shift.tookABreak == null)
				return null;

			Shift s = shiftRepository.GetById(shift.shiftId);

			if(s == null) return null;
			
			s.tookABreak = shift.tookABreak;

			genericRepository.Update(s);
			
			Shift smjena = genericRepository.GetById(shift.shiftId);
			Taxi taxi = new Taxi();
			User user = new User();

			if (smjena.taxiCompanyId.HasValue)
				taxi = taxiRepository.GetById(smjena.taxiCompanyId.Value);

			if (smjena.taxiDriverId.HasValue)
				user = userRepository.GetById(smjena.taxiDriverId.Value);

			return new ShiftVM
			{
				startTime = smjena.startTime,
				endTime = smjena.endTime,
				taxiName = taxi.taxiName,
				tookABreak = smjena.tookABreak,
				taxiDriverFirstName = user.firstName,
				taxiDriverLastName = user.lastName,
			};
		}
	}
}
