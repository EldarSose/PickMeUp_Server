using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<OrderVM>> GetAll()
        {
            var orders = orderService.GetAll();
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
        public ActionResult<OrderVM> GetById(int id)
        {
            var order = orderService.GetById(id);
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
        public ActionResult<OrderVM> Add([FromBody] OrderAdd order)
        {
            OrderVM? orderVM = orderService.Add(order);
            if (orderVM == null)
                return BadRequest();
            else
                return Ok(orderVM);
        }
        [HttpPut]
        public ActionResult<OrderVM> Edit([FromBody] OrderEdit order)
        {
            OrderVM? orderVM = orderService.Update(order);
            if (orderVM == null)
                return BadRequest();
            else
                return Ok(orderVM);
        }
        [HttpDelete]
        public ActionResult Delete(int order)
        {
            var deleted = orderService.Delete(order);
            if (deleted == false)
                return BadRequest();
            else
                return Ok();
        }
    }
}
