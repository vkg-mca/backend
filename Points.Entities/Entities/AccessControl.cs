﻿using System;
using System.Collections.Generic;

namespace Points.Entities.Entities
{
    public partial class AccessControl
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string RoleId { get; set; } = null!;
    }
}
