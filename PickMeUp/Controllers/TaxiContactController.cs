using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class TaxiContactController : Controller
	{
		private readonly ITaxiContactService taxiContactService;

		public TaxiContactController(ITaxiContactService taxiContactService)
		{
			this.taxiContactService = taxiContactService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<TaxiContactVM>> GetAll()
		{
			var taxiContacts = taxiContactService.GetAll();
			if (taxiContacts == null)
			{
				return NotFound();
			}
			else
			{

				return Ok(taxiContacts);
			}
		}
		[HttpGet]
		public ActionResult<TaxiContactVM> GetById(int id)
		{
			var taxiContact = taxiContactService.GetById(id);
			if (taxiContact == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(taxiContact);
			}
		}
		[HttpPost]
		public ActionResult<TaxiContactVM> Add([FromBody] TaxiContactAdd taxiContact)
		{
			TaxiContactVM? taxiContactVM = taxiContactService.Add(taxiContact);
			if (taxiContactVM == null)
				return BadRequest();
			else
				return Ok(taxiContactVM);
		}
		[HttpPut]
		public ActionResult<TaxiContactVM> Edit([FromBody] TaxiContactEdit taxiContact)
		{
			TaxiContactVM? taxiContactVM = taxiContactService.Update(taxiContact);
			if (taxiContactVM == null)
				return BadRequest();
			else
				return Ok(taxiContactVM);
		}
		[HttpDelete]
		public ActionResult Delete(int gender)
		{
			var deleted = taxiContactService.Delete(gender);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}
