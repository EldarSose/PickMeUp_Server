using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GenderController : Controller
    {
        private readonly IGenderService genderService;

        public GenderController(IGenderService genderService)
        {
            this.genderService = genderService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<GenderVM>> GetAll()
        {
            var genders = genderService.GetAll();
            if (genders == null)
            {
                return NotFound();
            }
            else
            {

                return Ok(genders);
            }
        }
        [HttpGet]
        public ActionResult<GenderVM> GetById(int id)
        {
            var gender = genderService.GetById(id);
            if (gender == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(gender);
            }
        }
        [HttpPost]
        public ActionResult<GenderVM> Add([FromBody] GenderAdd gender)
        {
            GenderVM? genderVM = genderService.Add(gender);
            if (genderVM == null)
                return BadRequest();
            else
                return Ok(genderVM);
        }
        [HttpPut]
        public ActionResult<GenderVM> Edit([FromBody] GenderEdit gender)
        {
            GenderVM? genderVM = genderService.Update(gender);
            if (genderVM == null)
                return BadRequest();
            else
                return Ok(genderVM);
        }
        [HttpDelete]
        public ActionResult Delete(int gender)
        {
            var deleted = genderService.Delete(gender);
            if (deleted == false)
                return BadRequest();
            else
                return Ok();
        }
    }
}
