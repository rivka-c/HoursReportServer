using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace DAL
{
    public class HourReportBL
    {
        private readonly ApplicationDbContext _context;

        public HourReportBL(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<HoursReport>> GetHoursConcentration()
        {
            return _context.HoursReport.Include(x => x.User).Include(p => p.Project).ToList();
        }

        public ActionResult<IEnumerable<Project>> GetProjects(int user)
        {

            var listProjectId1 = _context.ProjectUser.Where(p => p.UserId == user).Select(r => r.ProjectId);

            return _context.Project.Where(p => listProjectId1.Contains(p.Id)).ToList();

        }

        public ActionResult<User> GetUser(string user)
        {

            return _context.User.Where(u => u.Email == user).FirstOrDefault();

        }

        public bool PostHoursReport(HoursReportRequest hoursReportRequest)
        {
            _context.HoursReport.Add(new HoursReport() { FromDateTime = hoursReportRequest.FromDateTime, ToDateTime = hoursReportRequest.ToDateTime, UserId = hoursReportRequest.UserId, ProjectId = hoursReportRequest.ProjectId });
            _context.SaveChanges();
            return true;
            //CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
    }
}


