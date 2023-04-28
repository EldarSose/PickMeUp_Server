using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class ShiftController : Controller
	{
		private readonly IShiftService shiftService;

		public ShiftController(IShiftService shiftService)
		{
			this.shiftService = shiftService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<ShiftVM>> GetAll()
		{
			var shifts = shiftService.GetAll();
			if (shifts == null)
			{
				return NotFound();
			}
			else
			{

				return Ok(shifts);
			}
		}
		[HttpGet]
		public ActionResult<ShiftVM> GetById(int id)
		{
			var shift = shiftService.GetById(id);
			if (shift == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(shift);
			}
		}
		[HttpPost]
		public ActionResult<ShiftVM> Add([FromBody] ShiftAdd shift)
		{
			ShiftVM? shiftVM = shiftService.Add(shift);
			if (shiftVM == null)
				return BadRequest();
			else
				return Ok(shiftVM);
		}
		[HttpPut]
		public ActionResult<ShiftVM> Edit([FromBody] ShiftEdit shift)
		{
			ShiftVM? shiftVM = shiftService.Update(shift);
			if (shiftVM == null)
				return BadRequest();
			else
				return Ok(shiftVM);
		}
		[HttpDelete]
		public ActionResult Delete(int gender)
		{
			var deleted = shiftService.Delete(gender);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}
