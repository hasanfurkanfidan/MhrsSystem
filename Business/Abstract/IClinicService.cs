using Core.Utilities.Results;
using Entities.Dtos.Clinic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IClinicService
    {
        Task<IResult> CreateClinic(ClinicCreateDto clinicCreateDto);
    }
}
