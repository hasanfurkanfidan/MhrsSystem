using Core.DataAccess.EntityFrameworkCore;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfClinicDal : EfEntityRepositoryBase<Clinic>, IClinicDal
    {
        public EfClinicDal(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
