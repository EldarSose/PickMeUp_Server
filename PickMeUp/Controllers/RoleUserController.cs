using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class RoleUserController : Controller
	{
		private readonly IRoleUserService roleUserService;

		public RoleUserController(IRoleUserService roleUserService)
		{
			this.roleUserService = roleUserService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<RoleUserVM>> GetAll()
		{
			var roleUser = roleUserService.GetAll();
			if (roleUser == null)
			{
				return NotFound();
			}
			else
			{

				return Ok(roleUser);
			}
		}
		[HttpGet]
		public ActionResult<RoleUserVM> GetById(int id)
		{
			var roleUser = roleUserService.GetById(id);
			if (roleUser == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(roleUser);
			}
		}
		[HttpPost]
		public ActionResult<RoleUserVM> Add([FromBody] RoleUserAdd roleUser)
		{
			RoleUserVM? roleUserVM = roleUserService.Add(roleUser);
			if (roleUserVM == null)
				return BadRequest();
			else
				return Ok(roleUserVM);
		}
		[HttpPut]
		public ActionResult<RoleUserVM> Edit([FromBody] RoleUserEdit roleUser)
		{
			RoleUserVM? roleUserVM = roleUserService.Update(roleUser);
			if (roleUserVM == null)
				return BadRequest();
			else
				return Ok(roleUserVM);
		}
		[HttpDelete]
		public ActionResult Delete(int gender)
		{
			var deleted = roleUserService.Delete(gender);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}
