namespace Exam.Grade.DomainObjects
{
    public class AccessControl
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<string>? Permissions { get; set; }
    }
}
