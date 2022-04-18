using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class User : IdentityUser<int>, IEntity
    {
    }
}
