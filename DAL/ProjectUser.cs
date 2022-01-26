using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProjectUser
    {
       
            public int UserId { get; set; }
            public User User { get; set; }

            public int ProjectId { get; set; }
            public Project Project { get; set; }
       
    }
}
