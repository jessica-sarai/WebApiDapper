using System;
using System.Collections.Generic;

namespace Entities.Models.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            CursoInstructores = new HashSet<CursoInstructores>();
            CursosAlumnos = new HashSet<CursosAlumnos>();
        }

        public short Id { get; set; }
        public short? IdCatCurso { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaTermino { get; set; }
        public bool? Activo { get; set; }

        public virtual CatCursos IdCatCursoNavigation { get; set; }
        public virtual ICollection<CursoInstructores> CursoInstructores { get; set; }
        public virtual ICollection<CursosAlumnos> CursosAlumnos { get; set; }
    }
}
