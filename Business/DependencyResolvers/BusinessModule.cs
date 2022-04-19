using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers
{
    public static class BusinessModule
    {
        public static void Load(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentDal, EfAppointmentDal>();
            services.AddScoped<IAppointmentUserDal, EfAppointmentUserDal>();
            services.AddScoped<IBranchDal, EfBranchDal>();
            services.AddScoped<IClinicDal, EfClinicDal>();
            services.AddScoped<IDoctorDal, EfDoctorDal>();
            services.AddScoped<IDoctorTitleDal, EfDoctorTitleDal>();
            services.AddScoped<IHospitalDal, EfHospitalDal>();

            services.AddScoped<ITokenHelper, JwtTokenHelper>();
        }
    }
}
