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
	public class OrderService : BaseService<Order, int>, IOrderService
	{
		private readonly IOrderRepository orderRepository;

		public OrderService(IGenericRepository<Order, int> genericRepository,
			IOrderRepository orderRepository) : base(genericRepository)
		{
			this.orderRepository = orderRepository;
		}

		public OrderVM? Add(CarAdd car)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public OrderVM? Update(CarEdit car)
		{
			throw new NotImplementedException();
		}
	}
}
