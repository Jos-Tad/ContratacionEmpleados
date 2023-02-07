using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContratacionEmpleados.Models.ViewModels
{
    public class Area_VM
    {

        public int IdArea { get; set; }
        public string CodigoArea { get; set; }
        public string NombreArea { get; set; }
        public bool Activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}