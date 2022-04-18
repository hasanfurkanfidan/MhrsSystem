using Core.Entities;

namespace Entities.Concrete
{
    public class Doctor : IEntity
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int DoctorTitleId { get; set; }
        public DoctorTitle DoctorTitle { get; set; }
    }
}
