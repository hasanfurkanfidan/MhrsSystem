using System.Collections.Generic;

namespace Entities.Dtos.User
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; }
        public List<string> Roles { get; set; }
    }
}
