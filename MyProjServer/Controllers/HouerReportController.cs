﻿
/*using DAL;
using Microsoft.AspNetCore.Mvc;

namespace MyProjServer.Controllers
{
    [ApiController]
    [Route("[api/HoursReport]")]
    public class HouerReportController : ControllerBase
    {

        [HttpGet(Name = "GetHoursConcentration")]

        public IEnumerable<HoursReport> GetHoursConcentration()
        {
            return HourReportBL.GetHoursConcentration();
        }


       

    }
}*/


using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyProjServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoursReportController : ControllerBase
    {

        private readonly HourReportBL _hourReportBL;

        public HoursReportController(HourReportBL hourReportBL)
        {
            _hourReportBL = hourReportBL;
        }



        [HttpGet(Name = "GetProjects")]
        public ActionResult<IEnumerable<Project>> GetProjects(int user)
        {
            return _hourReportBL.GetProjects(user);
        }

        [HttpPost(Name = "PostHoursReport")]
        public bool Post(HoursReportRequest hoursReport)
        {
            return _hourReportBL.PostHoursReport(hoursReport);
        }
    }
}