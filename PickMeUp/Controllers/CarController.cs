using Microsoft.AspNetCore.Mvc;
using PickMeUp.Core.Entities;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class CarController : Controller
	{
		private readonly ICarService carService;

		public CarController(ICarService carService)
		{
			this.carService = carService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<CarVM>> GetAll()
		{
			var cars = carService.GetAll();
			if(cars == null)
			{
				return NotFound();
			}
			else
			{
				
				return Ok(cars);
			}
		}
		[HttpGet]
		public ActionResult<CarVM> GetById(int id)
		{
			var car = carService.GetById(id);
			if (car == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(car);
			}
		}
		[HttpPost]
		public ActionResult<CarVM> Add([FromBody] CarAdd car)
		{
		    CarVM? carVM = carService.Add(car);
			if (carVM == null)
				return BadRequest();
			else
				return Ok(carVM);
		}
		[HttpPut]
		public ActionResult<CarVM> Edit([FromBody]CarEdit car)
		{
			CarVM? carVM = carService.Update(car);
			if (carVM == null)
				return BadRequest();
			else 
				return Ok(carVM);
		}
		[HttpDelete]
		public ActionResult Delete(int car)
		{
			var deleted = carService.Delete(car);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}
