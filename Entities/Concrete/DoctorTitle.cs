using Core.Entities;

namespace Entities.Concrete
{
    public class DoctorTitle : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
