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
		private readonly IOrderStatusRepository orderStatusRepository;

		public OrderService(IGenericRepository<Order, int> genericRepository,
			IOrderRepository orderRepository,
			ITaxiRepository taxiRepository,
			IUserRepository userRepository,
			IOrderStatusRepository orderStatusRepository) : base(genericRepository)
		{
			this.orderRepository = orderRepository;
            this.taxiRepository = taxiRepository;
            this.userRepository = userRepository;
			this.orderStatusRepository = orderStatusRepository;
		}

		public OrderVM? Add(OrderAdd order)
		{
            if (order.taxiId == null || order.userId == null)
                return null;
			genericRepository.Add(new Order
			{
				taxiId=order.taxiId,
				userId=order.userId,
				isDeleted = false
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

			Order o = orderRepository.GetById(order.orderId);

			if (o == null) return null;

			o.timeUntilArrival = order.timeUntilArrival;
			o.taxiDriverId = order.taxiDriverId;
			o.orderStatusId = order.orderStatusId;
			genericRepository.Update(o);

			Order order1 = orderRepository.GetById(order.orderId);
			Taxi taxi = new Taxi();
			User user = new User();
			User taxiDriver = new User();
			OrderStatus status = new OrderStatus();
			if (order1 != null)
			{
				if (order1.taxiId != null)
				{
					taxi = taxiRepository.GetById((int)order1.taxiId);
				}
				if (order1.userId != null)
				{
					user = userRepository.GetById((int)order1.userId);
				}
				if (order1.taxiDriverId != null)
				{
					taxiDriver = userRepository.GetById((int)order1.taxiDriverId);
				}
				if (order1.orderStatusId != null)
				{
					status = orderStatusRepository.GetById((int)order1.orderStatusId);
				}
			}

			return new OrderVM
			{
				taxiName = taxi.taxiName,
				userFirstName = user.firstName,
				userLastName = user.lastName,
				driverFirstName = taxiDriver.firstName,
				driverLastName = taxiDriver.lastName,
				timeUntilArrival = order1.timeUntilArrival,
				orderStatusName = status.orderStatusName
			};
        }
	}
}
