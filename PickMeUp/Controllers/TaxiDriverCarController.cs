using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class TaxiDriverCarController : Controller
	{
		private readonly ITaxiDriverCarService taxiDriverCarService;

		public TaxiDriverCarController(ITaxiDriverCarService taxiDriverCarService)
		{
			this.taxiDriverCarService = taxiDriverCarService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<TaxiDriverCarVM>> GetAll()
		{
			var taxiDriverCars = taxiDriverCarService.GetAll();
			if (taxiDriverCars == null)
			{
				return NotFound();
			}
			else
			{

				return Ok(taxiDriverCars);
			}
		}
		[HttpGet]
		public ActionResult<TaxiDriverCarVM> GetById(int id)
		{
			var taxiDriver = taxiDriverCarService.GetById(id);
			if (taxiDriver == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(taxiDriver);
			}
		}
		[HttpPost]
		public ActionResult<TaxiDriverCarVM> Add([FromBody] TaxiDriverCarAdd taxiDriver)
		{
			TaxiDriverCarVM? taxiDriverCarVM = taxiDriverCarService.Add(taxiDriver);
			if (taxiDriverCarVM == null)
				return BadRequest();
			else
				return Ok(taxiDriverCarVM);
		}
		[HttpPut]
		public ActionResult<TaxiDriverCarVM> Edit([FromBody] TaxiDriverCarEdit taxiDriver)
		{
			TaxiDriverCarVM? taxiDriverCarVM = taxiDriverCarService.Update(taxiDriver);
			if (taxiDriverCarVM == null)
				return BadRequest();
			else
				return Ok(taxiDriverCarVM);
		}
		[HttpDelete]
		public ActionResult Delete(int gender)
		{
			var deleted = taxiDriverCarService.Delete(gender);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}
