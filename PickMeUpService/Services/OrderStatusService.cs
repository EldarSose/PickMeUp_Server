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
	public class OrderStatusService : BaseService<OrderStatus, int>, IOrderStatusService
	{
		private readonly IOrderStatusRepository orderStatusRepository;

		public OrderStatusService(IGenericRepository<OrderStatus, int> genericRepository,
			IOrderStatusRepository orderStatusRepository) : base(genericRepository)
		{
			this.orderStatusRepository = orderStatusRepository;
		}

		public OrderStatusVM? Add(OrderStatusAdd orderStatus)
		{
			if (string.IsNullOrWhiteSpace(orderStatus.orderStatusName) || string.IsNullOrWhiteSpace(orderStatus.orderStatusDescription))
				return null;
			genericRepository.Add(new OrderStatus
			{
				orderStatusName= orderStatus.orderStatusName,
				orderStatusDescription= orderStatus.orderStatusDescription
			});

			return new OrderStatusVM
			{
				orderStatusName= orderStatus.orderStatusName,
				orderStatusDescription= orderStatus.orderStatusDescription
			};
		}

		public bool Delete(int id)
		{
			return orderStatusRepository.Delete(id);
		}

		public OrderStatusVM? Update(OrderStatusEdit orderStatus)
		{
			if (string.IsNullOrWhiteSpace(orderStatus.orderStatusName) || string.IsNullOrWhiteSpace(orderStatus.orderStatusDescription))
				return null;

			OrderStatus os = orderStatusRepository.GetById(orderStatus.ordedStatusId);

			if(os == null) return null;

			os.orderStatusDescription = orderStatus.orderStatusDescription;
			os.orderStatusName = orderStatus.orderStatusName;
			genericRepository.Update(os);

			return new OrderStatusVM
			{
				orderStatusName = orderStatus.orderStatusName,
				orderStatusDescription = orderStatus.orderStatusDescription
			};
		}
	}
}
