using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.BootcampDto.Request
{
    public class CreateBootcampRequest
    {
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public int BootcampStateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
