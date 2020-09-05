using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiTest.Models
{
    /// <summary>
    /// Роли пользователей
    /// </summary>
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
            //ApiMethodRoles = new HashSet<ApiMethodRole>();
        }

        /// <summary>
        /// Ид 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя роли
        /// </summary>
        public string RoleName { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<ApiMethodRole> ApiMethodRoles { get; set; }
    }
}
