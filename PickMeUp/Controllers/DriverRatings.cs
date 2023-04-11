using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;
using PickMeUp.Service.Services;

namespace PickMeUp.API.Controllers
{
	public class DriverRatings : Controller
	{
		private readonly IDriverRatingsService driverRatingsService;

		public DriverRatings(IDriverRatingsService driverRatingsService)
		{
			this.driverRatingsService = driverRatingsService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<DriverRatingsVM>> GetAll()
		{
			var ratings = driverRatingsService.GetAll();
			if (ratings == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(ratings);
			}
		}
		[HttpGet]
		public ActionResult<DriverRatingsVM> GetById(int id)
		{
			var ratings = driverRatingsService.GetById(id);
			if (ratings == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(ratings);
			}
		}
		[HttpPost]
		public ActionResult<DriverRatingsVM> Add([FromBody] DriverRatingsAdd ratings)
		{
			DriverRatingsVM? ratingsVM = driverRatingsService.Add(ratings);
			if (ratingsVM == null)
				return BadRequest();
			else
				return Ok(ratingsVM);
		}
		[HttpPut]
		public ActionResult<DriverRatingsVM> Edit([FromBody] DriverRatingsEdit ratings)
		{
			DriverRatingsVM? ratingsVM = driverRatingsService.Update(ratings);
			if (ratingsVM == null)
				return BadRequest();
			else
				return Ok(ratingsVM);
		}
		[HttpDelete]
		public ActionResult Delete(int ratings)
		{
			var deleted = driverRatingsService.Delete(ratings);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}

