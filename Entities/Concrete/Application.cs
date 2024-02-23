using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entities.Concrete
{
    public class Application : BaseEntity<int>
    {
        public int ApplicantId { get; set; }
        public int BootcampId { get; set; }
        public int ApplicationStateId { get; set; }

        public Applicant Applicant { get; set; }
        public Bootcamp Bootcamp { get; set; }
        public ApplicationState ApplicationState { get; set; }

        
    }
}
