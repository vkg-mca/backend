﻿using System;
using System.Collections.Generic;

namespace Points.Entities.Entities
{
    public partial class RolePermission
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
