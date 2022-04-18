using Core.DataAccess.EntityFrameworkCore;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfHospitalDal : EfEntityRepositoryBase<Hospital>, IHospitalDal
    {
        public EfHospitalDal(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
