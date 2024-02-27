using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Blacklists.Responses
{
    public class GetAllBlacklistResponse
    {
        public int Id { get; set; }
        public string ApplicantUserName { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
    }
}
