using System;
using System.Collections.Generic;

namespace Points.Entities.Models
{
    public partial class Role
    {
        public Role()
        {
            RolePermissions = new HashSet<RolePermission>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
