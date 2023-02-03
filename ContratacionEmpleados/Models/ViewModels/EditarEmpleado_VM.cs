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
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]

        public int? Genero { get; set; }
        [Required]
        [StringLength(8)]
        [Display(Name = "Telefono")]
        public string TelefonoPersonal { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string EmailPersonal { get; set; }
        [Required]
        [Display(Name = "Tipo de sangre")]
        public string TipoSangre { get; set; }
      
        public string Fotografia { get; set; }
        public string file { get; set; }

    }
}