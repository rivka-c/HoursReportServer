

using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyProjServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly HourReportBL _hourReportBL;

        public UserController(HourReportBL hourReportBL)
        {
            _hourReportBL = hourReportBL;
        }

        [HttpGet(Name = "GetUser")]

        public ActionResult<User> GetUser(string user)
        {
            return _hourReportBL.GetUser(user);
        }

    }
}