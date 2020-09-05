using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiTest.Models
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
            //ApiMethodRoles = new HashSet<ApiMethodRole>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<ApiMethodRole> ApiMethodRoles { get; set; }
    }
}
