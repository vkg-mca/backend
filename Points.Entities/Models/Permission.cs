using System;
using System.Collections.Generic;

namespace Points.Entities.Models
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
