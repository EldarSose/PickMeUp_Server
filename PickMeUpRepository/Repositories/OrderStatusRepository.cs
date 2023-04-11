using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class OrderStatusRepository : GenericRepository<OrderStatus, int>, IOrderStatusRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public OrderStatusRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var OrderStatusRepository = dbContext.OrderStatuses.Find(id);
			if (OrderStatusRepository != null)
			{
				OrderStatusRepository.isDeleted = true;
				return true;
			}
			else
				return false;
		}
	}
}
