using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Hospital : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Clinic> Clinics { get; set; }
    }
}
