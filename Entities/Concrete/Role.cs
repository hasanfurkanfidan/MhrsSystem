using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class Role : IdentityRole<int>, IEntity
    {
    }
}
