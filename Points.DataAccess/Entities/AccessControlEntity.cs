using System;
using System.Collections.Generic;

namespace Points.DataAccess.Entities
{
    public class AccessControlEntity: BaseEntity<Guid>
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public IEnumerable<string>? Permissions { get; set; }
    }
}
