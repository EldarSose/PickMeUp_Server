﻿using PickMeUp.Core.Entities;
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
	public class ReviewsService : BaseService<Reviews, int>, IReviewsService
	{
		private readonly IReviewsRepository reviewsRepository;

		public ReviewsService(IGenericRepository<Reviews, int> genericRepository,
			IReviewsRepository reviewsRepository) : base(genericRepository)
		{
			this.reviewsRepository = reviewsRepository;
		}

		public ReviewsVM? Add(CarAdd car)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public ReviewsVM? Update(CarEdit car)
		{
			throw new NotImplementedException();
		}
	}
}