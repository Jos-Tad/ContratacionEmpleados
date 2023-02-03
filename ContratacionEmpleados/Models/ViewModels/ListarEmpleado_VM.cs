using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContratacionEmpleados.Models.ViewModels
{
    public class ListarEmpleado_VM
    {
        public int IdEmpleado { get; set; }
        
       
        public string Codigo { get; set; }
       
        public string Nombres { get; set; }
      
        public string Apellidos { get; set; }
     
        public int? Genero { get; set; }
     
        [Display(Name = "Telefono")]
        public string TelefonoPersonal { get; set; }
       
        [EmailAddress]
        [Display(Name = "Correo")]
        public string EmailPersonal { get; set; }
       
        [Display(Name = "Tipo de sangre")]
        public string TipoSangre { get; set; }
       
       
        public string Fotografia { get; set; }

        public string file { get; set; }

    }
     
    public class Listarcontrato
    {
        public int IdEmpleado { get; set; }
        public int IdContrato { get; set; }
        [Display(Name = "Fecha Inicio")]
        public DateTime? FechaInicio { get; set; }
        [Display(Name = "Fecha final")]
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