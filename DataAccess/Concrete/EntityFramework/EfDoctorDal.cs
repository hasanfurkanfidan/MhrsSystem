using Core.DataAccess.EntityFrameworkCore;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDoctorDal : EfEntityRepositoryBase<Doctor>, IDoctorDal
    {
        public EfDoctorDal(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
