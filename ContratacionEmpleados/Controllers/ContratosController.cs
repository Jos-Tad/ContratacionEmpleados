using ContratacionEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContratacionEmpleados.Controllers
{
    public class ContratosController : Controller
    {

        bd_PruebasEntities context = new bd_PruebasEntities();
        // GET: Contratos
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Models.ViewModels.Contrato_VM contrato_VM)
        {

            
            try
            {
               

                Contrato e = new Contrato();
                e.IdEmpleado = contrato_VM.IdEmpleado;
                e.IdArea = contrato_VM.IdArea;
                e.IdCargo = contrato_VM.IdCargo;
                e.TipoContrato = contrato_VM.TipoContrato;
                e.Salario = contrato_VM.Salario;
                e.FechaFin = contrato_VM.FechaFin;
                e.FechaInicio = contrato_VM.FechaInicio;
                e.EstadoFila = true;
                context.Contrato.Add(e);
                context.SaveChanges();
                return Redirect("~/Empleados");
            }
            catch (Exception e)
            {

            };





            return View();
        }
    }
}