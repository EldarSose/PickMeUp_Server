using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class TaxiController : Controller
	{
		private readonly ITaxiService taxiService;

		public TaxiController(ITaxiService taxiService)
		{
			this.taxiService = taxiService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<TaxiVM>> GetAll()
		{
			var taxis = taxiService.GetAll();
			if (taxis == null)
			{
				return NotFound();
			}
			else
			{

				return Ok(taxis);
			}
		}
		[HttpGet]
		public ActionResult<TaxiVM> GetById(int id)
		{
			var taxi = taxiService.GetById(id);
			if (taxi == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(taxi);
			}
		}
		[HttpPost]
		public ActionResult<TaxiVM> Add([FromBody] TaxiAdd taxi)
		{
			TaxiVM? taxiVM = taxiService.Add(taxi);
			if (taxiVM == null)
				return BadRequest();
			else
				return Ok(taxiVM);
		}
		[HttpPut]
		public ActionResult<TaxiVM> Edit([FromBody] TaxiEdit taxi)
		{
			TaxiVM? taxiVM = taxiService.Update(taxi);
			if (taxiVM == null)
				return BadRequest();
			else
				return Ok(taxiVM);
		}
		[HttpDelete]
		public ActionResult Delete(int gender)
		{
			var deleted = taxiService.Delete(gender);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}
