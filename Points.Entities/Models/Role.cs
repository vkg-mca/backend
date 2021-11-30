using System;
using System.Collections.Generic;

namespace Points.Entities.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
