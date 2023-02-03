using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContratacionEmpleados.Models.ViewModels
{
    public class Contrato_VM
    {
        public int IdEmpleado { get; set; }
        public int IdContrato { get; set; }
        [Display(Name = "Fecha Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy - MM - dd HH: mm}")]
        public DateTime? FechaInicio { get; set; }
        [Display(Name = "Fecha final")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy - MM - dd HH: mm}")]
        public DateTime? FechaFin { get; set; }
        public int? IdArea { get; set; }
        public int? IdCargo { get; set; }
        public int? TipoContrato { get; set; }
        public int? EstadoFila { get; set; }
        public double Salario { get; set; }
        [Display(Name = "Area")]
        public virtual Areas Areas { get; set; }
        [Display(Name = "Cargo")]
        public virtual Cargos Cargos { get; set; }
        [Display(Name = "Nombre")]
        public virtual Empleados Empleados { get; set; }
        [Display(Name = "Tipo de contrato")]
        public virtual TipoContrato TipoContrato1 { get; set; }

    }
}