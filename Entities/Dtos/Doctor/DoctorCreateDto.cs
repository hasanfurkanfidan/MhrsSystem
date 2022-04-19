namespace Entities.Dtos.Doctor
{
    public class DoctorCreateDto
    {
        public string Name { get; set; }
        public int BranchId { get; set; }
        public int DoctorTitleId { get; set; }
    }
}
