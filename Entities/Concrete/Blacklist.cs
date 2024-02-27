using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Blacklist : BaseEntity<int>
    {
        public int ApplicantId { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }

        public virtual Applicant Applicant { get; set; }

    }
}
