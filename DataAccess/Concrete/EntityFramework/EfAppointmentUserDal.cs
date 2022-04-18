using Core.DataAccess.EntityFrameworkCore;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAppointmentUserDal : EfEntityRepositoryBase<AppointmentUser>, IAppointmentUserDal
    {
        public EfAppointmentUserDal(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
