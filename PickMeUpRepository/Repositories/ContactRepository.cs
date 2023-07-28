using Microsoft.EntityFrameworkCore;
using PickMeUp.Core.Entities;
using PickMeUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Repositories
{
	public class ContactRepository : GenericRepository<Contact, int>, IContactRepository
	{
		private readonly PickMeUpDbContext dbContext;
		public ContactRepository(PickMeUpDbContext DBContext) : base(DBContext)
		{
			this.dbContext = DBContext;
		}
		public bool Delete(int id)
		{
			var contact = dbContext.Contacts.Find(id);
			if (contact != null)
			{
				contact.isDeleted = true;
				dbContext.SaveChanges();
				return true;
			}
			else
				return false;
		}
	}
}
