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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Service.Services
{
	public class OrderService : BaseService<Order, int>, IOrderService
	{
		private readonly IOrderRepository orderRepository;
        private readonly ITaxiRepository taxiRepository;
        private readonly IUserRepository userRepository;

        public OrderService(IGenericRepository<Order, int> genericRepository,
			IOrderRepository orderRepository,
			ITaxiRepository taxiRepository,
			IUserRepository userRepository) : base(genericRepository)
		{
			this.orderRepository = orderRepository;
            this.taxiRepository = taxiRepository;
            this.userRepository = userRepository;
        }

		public OrderVM? Add(OrderAdd order)
		{
            if (order.taxiId == null || order.userId == null)
                return null;
			genericRepository.Add(new Order
			{
				taxiId=order.taxiId,
				userId=order.userId
			});
			
			Taxi taxi = taxiRepository.GetById(order.taxiId);
			User user = userRepository.GetById(order.userId);

			return new OrderVM
			{
				taxiName = taxi.taxiName,
				userFirstName = user.firstName,
				userLastName = user.lastName
			}; 
        }

		public bool Delete(int id)
		{
			return orderRepository.Delete(id);
		}

		public OrderVM? Update(OrderEdit order)
		{
            if (order.orderStatusId == null || order.taxiDriverId == null || order.timeUntilArrival == null)
                return null;
			genericRepository.Update(new Order
			{
				orderId = order.orderId,
				orderStatusId = order.orderStatusId,
				taxiDriverId = order.taxiDriverId,
				timeUntilArrival = order.timeUntilArrival
			});

			Order order1 = orderRepository.GetById(order.orderId);

			//if (order1 != null)
			//{
			//	if(order1.taxiId != null)
			//	{
			//		Taxi taxi = taxiRepository.GetById(order1.taxiId);
			//	}
			//	User user = userRepository.GetById(order1.userId);

			//}

			//         return new OrderVM
			//         {
			//             taxiName = taxi.taxiName,
			//             userFirstName = user.firstName,
			//             userLastName = user.lastName
			//         };
			return new OrderVM { };
        }
	}
}
