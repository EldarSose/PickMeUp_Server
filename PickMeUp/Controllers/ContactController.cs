using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;
using PickMeUp.Service.Services;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class ContactController : Controller
	{
		private readonly IContactService contactService;

		public ContactController(IContactService contactService)
		{
			this.contactService = contactService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<ContactVM>> GetAll()
		{
			var contacts = contactService.GetAll();
			if (contacts == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(contacts);
			}
		}
		[HttpGet]
		public ActionResult<ContactVM> GetById(int id)
		{
			var contact = contactService.GetById(id);
			if (contact == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(contact);
			}
		}
		[HttpPost]
		public ActionResult<ContactVM> Add([FromBody] ContactAdd contact)
		{
			ContactVM? ContactVM = contactService.Add(contact);
			if (ContactVM == null)
				return BadRequest();
			else
				return Ok(ContactVM);
		}
		[HttpPut]
		public ActionResult<ContactVM> Edit([FromBody] ContactEdit contact)
		{
			ContactVM? ContactVM = contactService.Update(contact);
			if (ContactVM == null)
				return BadRequest();
			else
				return Ok(ContactVM);
		}
		[HttpDelete]
		public ActionResult Delete(int contact)
		{
			var deleted = contactService.Delete(contact);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}

