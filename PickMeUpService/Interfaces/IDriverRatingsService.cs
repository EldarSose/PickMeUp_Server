using PickMeUp.Core.Entities;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Service.Interfaces
{
	public interface IDriverRatingsService : IBaseService<DriverRatings, int>
	{
		bool Delete(int id);
		DriverRatingsVM? Add(DriverRatingsAdd ratings);
		DriverRatingsVM? Update(DriverRatingsEdit ratings);
	}
}
