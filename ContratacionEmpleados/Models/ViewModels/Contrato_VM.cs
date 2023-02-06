using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContratacionEmpleados.Models.ViewModels
{
    public class Contrato_VM
    {

        public int IdContrato { get; set; }
        public int IdEmpleado { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<int> IdArea { get; set; }
        public Nullable<int> IdCargo { get; set; }
        public Nullable<int> TipoContrato { get; set; }
        public Nullable<bool> EstadoFila { get; set; }
        public double Salario { get; set; }

        public virtual Areas Areas { get; set; }
        public virtual Cargos Cargos { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual TipoContrato TipoContrato1 { get; set; }
    }
}