using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiTest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int RoleId { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual Role Role { get; set; }
    }
}
