using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class OrderStatusController : Controller
	{
		private readonly IOrderStatusService orderStatusService;

		public OrderStatusController(IOrderStatusService orderStatusService)
		{
			this.orderStatusService = orderStatusService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<OrderStatusVM>> GetAll()
		{
			var orders = orderStatusService.GetAll();
			if (orders == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(orders);
			}
		}
		[HttpGet]
		public ActionResult<OrderStatusVM> GetById(int id)
		{
			var order = orderStatusService.GetById(id);
			if (order == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(order);
			}
		}
		[HttpPost]
		public ActionResult<OrderStatusVM> Add([FromBody] OrderStatusAdd order)
		{
			OrderStatusVM? orderVM = orderStatusService.Add(order);
			if (orderVM == null)
				return BadRequest();
			else
				return Ok(orderVM);
		}
		[HttpPut]
		public ActionResult<OrderStatusVM> Edit([FromBody] OrderStatusEdit order)
		{
			OrderStatusVM? orderVM = orderStatusService.Update(order);
			if (orderVM == null)
				return BadRequest();
			else
				return Ok(orderVM);
		}
		[HttpDelete]
		public ActionResult Delete(int order)
		{
			var deleted = orderStatusService.Delete(order);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}
