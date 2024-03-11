using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Entities
{
    public class UserOperationClaim : BaseEntity<int>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public virtual User User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }

        public UserOperationClaim()
        {
        }

        public UserOperationClaim(int id,int userId,int operationClaim):this()
        {
            Id = id;
            UserId = userId;
            OperationClaimId = operationClaim;
        }

    }
}
