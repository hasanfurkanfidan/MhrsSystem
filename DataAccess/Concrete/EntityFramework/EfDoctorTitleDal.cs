using Core.DataAccess.EntityFrameworkCore;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDoctorTitleDal : EfEntityRepositoryBase<DoctorTitle>, IDoctorTitleDal
    {
        public EfDoctorTitleDal(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
