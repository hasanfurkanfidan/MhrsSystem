using Core.Entities;

namespace Entities.Concrete
{
    public class AppointmentUser : IEntity
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
    }
}
