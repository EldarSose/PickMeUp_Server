using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class OrderRepository : GenericRepository<Order, int>, IOrderRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public OrderRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var Orders = dbContext.Orders.Find(id);
			if (Orders != null)
			{
				Orders.isDeleted = true;
				return true;
			}
			else
				return false;
		}
	}
}
