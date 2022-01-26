using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoursReportRequest
    {
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; }

    }
}
