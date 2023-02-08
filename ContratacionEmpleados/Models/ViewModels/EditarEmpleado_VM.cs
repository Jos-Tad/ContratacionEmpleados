using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContratacionEmpleados.Models.ViewModels
{
    public class EditarEmpleado_VM
    {
        public int IdEmpleado { get; set; }
        
        public string Codigo { get; set; }
      
        public string Nombres { get; set; }
        
        public string Apellidos { get; set; }
        

        public int? Genero { get; set; }
        [Required]
        [StringLength(8)]
        [Display(Name = "Telefono")]
        public string TelefonoPersonal { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string EmailPersonal { get; set; }
        
        [Display(Name = "Tipo de sangre")]
        public string TipoSangre { get; set; }
      
        public string Fotografia { get; set; }
        [Required]
        public string file { get; set; }

        public int IdContrato { get; set; }
        
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