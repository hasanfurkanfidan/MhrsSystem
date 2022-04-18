using Core.Entities;

namespace Entities.Concrete
{
    public class Clinic : IEntity
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
