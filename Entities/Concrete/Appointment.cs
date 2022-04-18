using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public bool Reserved { get; set; }
        public Clinic Clinic { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
