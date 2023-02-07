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
     
   
}