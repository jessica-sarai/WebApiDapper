using System;
using System.Collections.Generic;

namespace Entities.Models.Models
{
    public partial class VistaAlumnos
    {
        public string Curp { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string SegundoApellido { get; set; }
        public string PrimerApellido { get; set; }
        public string Nombre { get; set; }
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Estatus { get; set; }
    }
}
