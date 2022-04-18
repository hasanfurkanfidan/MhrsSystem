using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IClinicDal : IEntityRepository<Clinic>
    {
    }
}
