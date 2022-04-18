using Core.DataAccess.EntityFrameworkCore;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBranchDal : EfEntityRepositoryBase<Branch>, IBranchDal
    {
        public EfBranchDal(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
