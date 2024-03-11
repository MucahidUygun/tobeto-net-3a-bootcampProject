using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Entities
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalIdentity { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

        public User(int id, string email, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, byte[] passwordHash, byte[] passwordSalt) : this()
        {
            Id = id;
            Email = email;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }

    }
}
