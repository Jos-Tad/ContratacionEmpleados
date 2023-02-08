using ContratacionEmpleados.Models;
using ContratacionEmpleados.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContratacionEmpleados.Controllers
{
    public class EmpleadoContratoController : Controller
    {

        bd_PruebasEntities context = new bd_PruebasEntities();
        // GET: EmpleadoContrato
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmpleadoContrato/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpleadoContrato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoContrato/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoContrato/Edit/5
        public ActionResult Editar(int id)
        {
            EmpleadoContrato_VM context = new EmpleadoContrato_VM();
            using (bd_PruebasEntities db = new bd_PruebasEntities())
            {

               
                var e = db.Contrato.SqlQuery("SELECT * FROM Contrato Where IdEmpleado = id");


                //context.IdEmpleado = e.IdEmpleado;
                //context.IdArea = e.IdArea;
                //context.IdCargo = e.IdCargo;
                //context.TipoContrato = e.TipoContrato;
                //context.Salario = e.Salario;
                //context.FechaFin = e.FechaFin;
                //context.FechaInicio = e.FechaInicio;
                //context.IdContrato = e.IdContrato;
                //context.EstadoFila = e.EstadoFila;


            }




            return View(context);
        }

        [HttpPost]
        public ActionResult Editar(EmpleadoContrato_VM context)
        {

            try
            {



                using (bd_PruebasEntities db = new bd_PruebasEntities())
                {

                    var e = db.Contrato.Find(context.IdContrato);
                    var a = db.Empleados.Find(context.IdEmpleado);


                    e.IdEmpleado = context.IdEmpleado;
                    e.IdCargo = context.IdCargo;
                    e.IdArea = context.IdArea;
                    e.FechaInicio = context.FechaInicio;
                    e.FechaFin = context.FechaFin;
                    e.TipoContrato = context.TipoContrato;
                    e.EstadoFila = true;
                    e.IdContrato = context.IdContrato;
                    db.Entry(e).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return Redirect("~/Empleados/");
                }
            }
            catch (Exception e)
            {

            };

            return View();


        }

        // GET: EmpleadoContrato/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadoContrato/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
