using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyProjServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoursConcentrationController : ControllerBase
    {

        private readonly HourReportBL _hourReportBL;

        public HoursConcentrationController(HourReportBL hourReportBL)
        {
            _hourReportBL = hourReportBL;
        }

        [HttpGet(Name = "GetHoursConcentration")]

        public ActionResult<IEnumerable<HoursReport>> Get()
        {
            return _hourReportBL.GetHoursConcentration();
        }

    }
}