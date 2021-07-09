using System;
using System.Collections.Generic;

namespace Entities.Models.Models
{
    public partial class Saldos
    {
        public Saldos()
        {
            TransaccionesIdDestinoNavigation = new HashSet<Transacciones>();
            TransaccionesIdOrigenNavigation = new HashSet<Transacciones>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Saldo { get; set; }

        public virtual ICollection<Transacciones> TransaccionesIdDestinoNavigation { get; set; }
        public virtual ICollection<Transacciones> TransaccionesIdOrigenNavigation { get; set; }
    }
}
