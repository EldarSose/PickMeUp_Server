using Microsoft.AspNetCore.Mvc;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Service.Interfaces;

namespace PickMeUp.API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class ReportController : Controller
	{
		private readonly IReportService reportService;

		public ReportController(IReportService reportService)
		{
			this.reportService = reportService;
		}
		[HttpGet]
		public ActionResult<IEnumerable<ReportVM>> GetAll()
		{
			var reports = reportService.GetAll();
			if (reports == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(reports);
			}
		}
		[HttpGet]
		public ActionResult<ReportVM> GetById(int id)
		{
			var report = reportService.GetById(id);
			if (report == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(report);
			}
		}
		[HttpPost]
		public ActionResult<ReportVM> Add([FromBody] ReportAdd ratings)
		{
			ReportVM? reportVM = reportService.Add(ratings);
			if (reportVM == null)
				return BadRequest();
			else
				return Ok(reportVM);
		}
		[HttpPut]
		public ActionResult<ReportVM> Edit([FromBody] ReportEdit ratings)
		{
			ReportVM? reportVM = reportService.Update(ratings);
			if (reportVM == null)
				return BadRequest();
			else
				return Ok(reportVM);
		}
		[HttpDelete]
		public ActionResult Delete(int ratings)
		{
			var deleted = reportService.Delete(ratings);
			if (deleted == false)
				return BadRequest();
			else
				return Ok();
		}
	}
}
