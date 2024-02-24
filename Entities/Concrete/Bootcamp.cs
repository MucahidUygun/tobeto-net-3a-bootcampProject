using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Bootcamp : BaseEntity<int>
    {
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BootcampStateId { get; set; }
        public Instructor Instructor { get; set; }
        public BootcampState BootcampState { get; set; }
        public ICollection<Application> Applications { get; set; }
        public ICollection<BootcampImage>BootcampImages { get; set; }

        public Bootcamp()
        {
            Applications = new HashSet<Application>();
            BootcampImages = new HashSet<BootcampImage>();
        }


    }
}
