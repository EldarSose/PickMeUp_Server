using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class ReviewsController : Controller
	{
		private readonly IReviewsService reviewsService;

		public ReviewsController(IReviewsService reviewsService)
		{
			this.reviewsService = reviewsService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<ReviewsVM>> GetAll()
		{
			var reviews = reviewsService.GetAll();
			if (reviews == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(reviews);
			}
		}
		[HttpGet]
		public ActionResult<ReviewsVM> GetById(int id)
		{
			var review = reviewsService.GetById(id);
			if (review == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(review);
			}
		}
		[HttpPost]
		public ActionResult<ReviewsVM> Add([FromBody] ReviewsAdd review)
		{
			ReviewsVM? reviewVM = reviewsService.Add(review);
			if (reviewVM == null)
				return BadRequest();
			else
				return Ok(reviewVM);
		}
		[HttpPut]
		public ActionResult<ReviewsVM> Edit([FromBody] ReviewsEdit review)
		{
			ReviewsVM? reviewVM = reviewsService.Update(review);
			if (reviewVM == null)
				return BadRequest();
			else
				return Ok(reviewVM);
		}
		[HttpDelete]
		public ActionResult Delete(int contact)
		{
			var deleted = reviewsService.Delete(contact);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}
