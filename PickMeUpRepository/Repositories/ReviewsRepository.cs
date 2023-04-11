using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class ReviewsRepository : GenericRepository<Reviews, int>, IReviewsRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public ReviewsRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var Reviews = dbContext.Reviews.Find(id);
			if (Reviews != null)
			{
				Reviews.isDeleted = true;
				return true;
			}
			else
				return false;
		}
	}
}
