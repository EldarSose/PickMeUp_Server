using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class ReportTypeController : Controller
	{
		private readonly IReportTypeService reportTypeService;

		public ReportTypeController(IReportTypeService reportTypeService)
		{
			this.reportTypeService = reportTypeService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<ReportTypeVM>> GetAll()
		{
			var reportTypes = reportTypeService.GetAll();
			if (reportTypes == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(reportTypes);
			}
		}
		[HttpGet]
		public ActionResult<ReportTypeVM> GetById(int id)
		{
			var reportType = reportTypeService.GetById(id);
			if (reportType == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(reportType);
			}
		}
		[HttpPost]
		public ActionResult<ReportTypeVM> Add([FromBody] ReportTypeAdd reportType)
		{
			ReportTypeVM? reportTypeVM = reportTypeService.Add(reportType);
			if (reportTypeVM == null)
				return BadRequest();
			else
				return Ok(reportTypeVM);
		}
		[HttpPut]
		public ActionResult<ReportTypeVM> Edit([FromBody] ReportTypeEdit reportType)
		{
			ReportTypeVM? reportTypeVM = reportTypeService.Update(reportType);
			if (reportTypeVM == null)
				return BadRequest();
			else
				return Ok(reportTypeVM);
		}
		[HttpDelete]
		public ActionResult Delete(int contact)
		{
			var deleted = reportTypeService.Delete(contact);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}
