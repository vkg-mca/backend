using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Grade.DomainObjects
{
    public class AccessControl
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public IEnumerable<string> Permissions { get; set; }
    }
}
