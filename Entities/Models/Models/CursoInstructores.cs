using System;
using System.Collections.Generic;

namespace Entities.Models.Models
{
    public partial class CursoInstructores
    {
        public int Id { get; set; }
        public short IdCurso { get; set; }
        public short IdInstructor { get; set; }
        public DateTime? FechaContratación { get; set; }

        public virtual Cursos IdCursoNavigation { get; set; }
        public virtual Instructores IdInstructorNavigation { get; set; }
    }
}
