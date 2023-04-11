using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository
{
	public interface IGenericRepository<TEntity, TKey>
	{
		IEnumerable<TEntity> GetAll();
		TEntity GetById(TKey id);
		void Add(TEntity entity);
		void Update(TEntity entity);
	}
	public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
	{
		private readonly PickMeUpDbContext dbContext;
		private readonly DbSet<TEntity> dbSet;

		public GenericRepository(PickMeUpDbContext DBContext)
		{
			this.dbContext = DBContext;
			dbSet = DBContext.Set<TEntity>();
		}
		public void Add(TEntity entity)
		{
			dbSet.Add(entity);
			dbContext.SaveChanges();
		}

		public IEnumerable<TEntity> GetAll()
		{
			return dbSet.AsEnumerable();
		}
		public TEntity GetById(TKey id)
		{
			return dbSet.Find(id);
		}

		public void Update(TEntity entity)
		{
			dbSet.Update(entity);
			dbContext.SaveChanges();
		}
	}
}
