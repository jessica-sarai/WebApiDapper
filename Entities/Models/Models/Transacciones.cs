using System;
using System.Collections.Generic;

namespace Entities.Models.Models
{
    public partial class Transacciones
    {
        public int Id { get; set; }
        public int? IdOrigen { get; set; }
        public int? IdDestino { get; set; }
        public int? Monto { get; set; }

        public virtual Saldos IdDestinoNavigation { get; set; }
        public virtual Saldos IdOrigenNavigation { get; set; }
    }
}
