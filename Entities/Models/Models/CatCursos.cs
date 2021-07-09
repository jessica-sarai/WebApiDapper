using System;
using System.Collections.Generic;

namespace Entities.Models.Models
{
    public partial class CatCursos
    {
        public CatCursos()
        {
            Cursos = new HashSet<Cursos>();
            InverseIdPreRequisitoNavigation = new HashSet<CatCursos>();
        }

        public short Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte Horas { get; set; }
        public short? IdPreRequisito { get; set; }
        public bool Activo { get; set; }

        public virtual CatCursos IdPreRequisitoNavigation { get; set; }
        public virtual ICollection<Cursos> Cursos { get; set; }
        public virtual ICollection<CatCursos> InverseIdPreRequisitoNavigation { get; set; }
    }
}
