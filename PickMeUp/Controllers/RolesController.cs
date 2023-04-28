using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class RolesController : Controller
	{
		private readonly IRolesService rolesService;

		public RolesController(IRolesService rolesService)
		{
			this.rolesService = rolesService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<RolesVM>> GetAll()
		{
			var roles = rolesService.GetAll();
			if (roles == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(roles);
			}
		}
		[HttpGet]
		public ActionResult<RolesVM> GetById(int id)
		{
			var roles = rolesService.GetById(id);
			if (roles == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(roles);
			}
		}
		[HttpPost]
		public ActionResult<RolesVM> Add([FromBody] RolesAdd roles)
		{
			RolesVM? rolesVM = rolesService.Add(roles);
			if (rolesVM == null)
				return BadRequest();
			else
				return Ok(rolesVM);
		}
		[HttpPut]
		public ActionResult<RolesVM> Edit([FromBody] RolesEdit roles)
		{
			RolesVM? rolesVM = rolesService.Update(roles);
			if (rolesVM == null)
				return BadRequest();
			else
				return Ok(rolesVM);
		}
		[HttpDelete]
		public ActionResult Delete(int contact)
		{
			var deleted = rolesService.Delete(contact);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}
