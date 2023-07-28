using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class TaxiContactRepository : GenericRepository<TaxiContact, int>, ITaxiContactRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public TaxiContactRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var TaxiContacts = dbContext.TaxiContacts.Find(id);
			if (TaxiContacts != null)
			{
				TaxiContacts.isDeleted = true;
				dbContext.SaveChanges();
				return true;
			}
			else
				return false;
		}
	}
}
