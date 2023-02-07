using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContratacionEmpleados.Models.ViewModels
{
    public class TipoContrato_VM
    {
        public int IdTipoContrato { get; set; }
        public string NombreTipoContrato { get; set; }
        public bool AplicaAguinaldo { get; set; }
        public bool AplicaIndemnizacion { get; set; }
        public bool Activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}