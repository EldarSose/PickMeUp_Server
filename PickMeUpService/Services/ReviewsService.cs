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
	public class ReviewsService : BaseService<Reviews, int>, IReviewsService
	{
		private readonly IReviewsRepository reviewsRepository;
		private readonly IUserRepository userRepository;
		private readonly ITaxiRepository taxiRepository;

		public ReviewsService(IGenericRepository<Reviews, int> genericRepository,
			IReviewsRepository reviewsRepository,
			IUserRepository userRepository,
			ITaxiRepository taxiRepository) : base(genericRepository)
		{
			this.reviewsRepository = reviewsRepository;
			this.userRepository = userRepository;
			this.taxiRepository = taxiRepository;
		}

		public ReviewsVM? Add(ReviewsAdd review)
		{
			if (string.IsNullOrWhiteSpace(review.comment) || review.rating == null)
				return null;

			genericRepository.Add(new Reviews
			{
				taxiId = review.taxiId,
				userId = review.userId,
				comment = review.comment,
				rating = review.rating,
				isDeleted = false
			});

			Taxi taxi = taxiRepository.GetById(review.taxiId);
			User user = userRepository.GetById(review.userId);

			return new ReviewsVM
			{
				taxiName = taxi.taxiName,
				userFirstName= user.firstName,
				userLastName= user.lastName,
				comment= review.comment,
				rating = review.rating,
			};
		}

		public bool Delete(int id)
		{
			return reviewsRepository.Delete(id);
		}

		public ReviewsVM? Update(ReviewsEdit review)
		{
			if (string.IsNullOrWhiteSpace(review.comment) || review.rating == null)
				return null;

			Reviews r = reviewsRepository.GetById(review.reviewId);

			if (r == null) return null;

			r.comment = review.comment;
			r.rating = review.rating;

			genericRepository.Update(r);
			Taxi taxi = new Taxi();
			Reviews rev = reviewsRepository.GetById(review.reviewId);
			if(rev.taxiId.HasValue)
				taxi = taxiRepository.GetById(rev.taxiId.Value);

			User user = new User();
			if(rev.userId.HasValue)
				user = userRepository.GetById(rev.userId.Value);

			return new ReviewsVM
			{
				taxiName = taxi.taxiName,
				userFirstName = user.firstName,
				userLastName = user.lastName,
				comment = review.comment,
				rating = review.rating,
			};
		}
	}
}
