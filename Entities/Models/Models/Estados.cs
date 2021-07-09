using System;
using System.Collections.Generic;

namespace Entities.Models.Models
{
    public partial class Estados
    {
        public Estados()
        {
            Alumnos = new HashSet<Alumnos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Alumnos> Alumnos { get; set; }
    }
}
