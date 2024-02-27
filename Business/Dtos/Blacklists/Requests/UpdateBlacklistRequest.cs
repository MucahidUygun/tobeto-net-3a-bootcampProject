using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Blacklists.Requests
{
    public class UpdateBlacklistRequest
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public string Reason { get; set; }
    }
}
