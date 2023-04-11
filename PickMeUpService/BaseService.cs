using PickMeUp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Service
{
		public interface IBaseService<TEntity, TKey>
		{
			void Add(TEntity entity);
			void Update(TEntity entity);
			IEnumerable<TEntity> GetAll();
			TEntity GetById(TKey id);
		}
		public class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey> where TEntity : class
		{
			public readonly IGenericRepository<TEntity, TKey> genericRepository;

			public BaseService(IGenericRepository<TEntity, TKey> genericRepository)
			{
				this.genericRepository = genericRepository;
			}
			public void Add(TEntity entity)
			{
				genericRepository.Add(entity);
			}

			public IEnumerable<TEntity> GetAll()
			{
				return genericRepository.GetAll();
			}

			public TEntity GetById(TKey id)
			{
				return genericRepository.GetById(id);
			}

			public void Update(TEntity entity)
			{
				genericRepository.Update(entity);
			}
		}
}
