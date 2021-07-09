using System;
using System.Collections.Generic;

namespace Entities.Models.Models
{
    public partial class Alumnos
    {
        public Alumnos()
        {
            CursosAlumnos = new HashSet<CursosAlumnos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Curp { get; set; }
        public int IdEstadoOrigen { get; set; }
        public short IdEstatus { get; set; }

        public virtual Estados IdEstadoOrigenNavigation { get; set; }
        public virtual EstatusAlumnos IdEstatusNavigation { get; set; }
        public virtual ICollection<CursosAlumnos> CursosAlumnos { get; set; }
    }
}
