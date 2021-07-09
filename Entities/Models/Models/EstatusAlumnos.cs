using System;
using System.Collections.Generic;

namespace Entities.Models.Models
{
    public partial class EstatusAlumnos
    {
        public EstatusAlumnos()
        {
            Alumnos = new HashSet<Alumnos>();
        }

        public short Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Alumnos> Alumnos { get; set; }
    }
}
