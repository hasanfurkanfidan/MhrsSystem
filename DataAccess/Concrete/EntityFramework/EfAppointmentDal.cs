using Core.DataAccess.EntityFrameworkCore;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAppointmentDal : EfEntityRepositoryBase<Appointment>, IAppointmentDal
    {
        public EfAppointmentDal(AppDbContext appDbContext):base(appDbContext)
        {

        }
    }
}
