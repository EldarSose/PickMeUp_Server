using PickMeUp.Core.Entities;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Service.Interfaces
{
	public interface ICarService: IBaseService<Car, int>
	{
		bool Delete(int id);
		CarVM? Add(CarAdd car);
		CarVM? Update(CarEdit car);
	}
}
