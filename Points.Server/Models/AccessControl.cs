using Points.Entities.Models;

namespace Points.Server.Models
{
    public class AccessControl
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<Permission?> Permissions { get; set; }
    }
}
