using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class UserAccountController : Controller
	{
		private readonly IUserAccountService userAccountService;

		public UserAccountController(IUserAccountService userAccountService)
		{
			this.userAccountService = userAccountService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<UserAccountVM>> GetAll()
		{
			var userAccounts = userAccountService.GetAll();
			if (userAccounts == null)
			{
				return NotFound();
			}
			else
			{

				return Ok(userAccounts);
			}
		}
		[HttpGet]
		public ActionResult<UserAccountVM> GetById(int id)
		{
			var userAccount = userAccountService.GetById(id);
			if (userAccount == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(userAccount);
			}
		}
		[HttpPost]
		public ActionResult<UserAccountVM> Add([FromBody] UserAccountAdd userAccount)
		{
			UserAccountVM? userAccountVM = userAccountService.Add(userAccount);
			if (userAccountVM == null)
				return BadRequest();
			else
				return Ok(userAccountVM);
		}
		[HttpPut]
		public ActionResult<UserAccountVM> Edit([FromBody] UserAccountEdit userAccount)
		{
			UserAccountVM? userAccountVM = userAccountService.Update(userAccount);
			if (userAccountVM == null)
				return BadRequest();
			else
				return Ok(userAccountVM);
		}
		[HttpDelete]
		public ActionResult Delete(int gender)
		{
			var deleted = userAccountService.Delete(gender);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}
