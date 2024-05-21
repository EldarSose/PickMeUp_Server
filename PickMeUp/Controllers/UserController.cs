using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class UserController : Controller
	{
		private readonly IUserService userService;

		public UserController(IUserService userService)
		{
			this.userService = userService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<UserVM>> GetAll()
		{
			var users = userService.GetAll();
			if (users == null)
			{
				return NotFound();
			}
			else
			{

				return Ok(users);
			}
		}
		[HttpGet]
		public ActionResult<UserVM> GetById(int id)
		{
			var user = userService.GetById(id);
			if (user == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(user);
			}
		}
		[HttpPost]
		public ActionResult<UserVM> Add([FromBody] UserAdd user)
		{
			UserVM? userVM = userService.Add(user);
			if (userVM == null)
				return BadRequest();
			else
				return Ok();
		}
		[HttpPut]
		public ActionResult<UserVM> Edit([FromBody] UserEdit user)
		{
			UserVM? userVM = userService.Update(user);
			if (userVM == null)
				return BadRequest();
			else
				return Ok(userVM);
		}
		[HttpDelete]
		public ActionResult Delete(int gender)
		{
			var deleted = userService.Delete(gender);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
		[HttpPost]
		public ActionResult<UserVM> Login([FromBody] LoginVM login)
		{
			var user = userService.Login(login);
			if (user == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(user);
			}
		}
	}
}
