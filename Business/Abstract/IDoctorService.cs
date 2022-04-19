using Core.Utilities.Results;
using Entities.Dtos.Doctor;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDoctorService
    {
        Task<IResult> Create(DoctorCreateDto doctorCreateDto);
    }
}
