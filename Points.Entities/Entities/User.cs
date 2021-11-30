using System;
using System.Collections.Generic;

namespace Points.Entities.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
