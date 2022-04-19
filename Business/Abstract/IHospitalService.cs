using Core.Utilities.Results;
using Entities.Dtos.Hospital;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHospitalService
    {
        Task<IResult> CreateHospital(HospitalCreateDto hospitalCreateDto);
    }
}
