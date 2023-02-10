using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContratacionEmpleados.Models.ViewModels
{
    public class VwListarContrato
    {

        public string Nombres { get; set; }
        public int IdContrato { get; set; }
        public string Codigo { get; set; }
        public Nullable<bool> EstadoFila { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Inicio")]
        public Nullable<System.DateTime> FechaInicio { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Final")]
        public Nullable<System.DateTime> FechaFin { get; set; }
        public double Salario { get; set; }
        [Display(Name = "Nombre del Area")]
        public string NombreArea { get; set; }
        [Display(Name = "Nombre del Cargo")]
        public string NombreCargo { get; set; }
        [Display(Name = "Tipo de Contrato")]
        public string NombreTipoContrato { get; set; }

        public string SalarioClaculado { get; set; }
    }
}