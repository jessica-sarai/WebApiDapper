using System;
using System.Collections.Generic;

namespace Entities.Models.Models
{
    public partial class Instructores
    {
        public Instructores()
        {
            CursoInstructores = new HashSet<CursoInstructores>();
        }

        public short Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public decimal Cuota { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<CursoInstructores> CursoInstructores { get; set; }
    }
}
