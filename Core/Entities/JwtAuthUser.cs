using System.Collections.Generic;

namespace Core.Entities
{
    public class JwtAuthUser
    {
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
