using System.Collections.Generic;

namespace Core.Entities
{
    public class JwtAuthUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
