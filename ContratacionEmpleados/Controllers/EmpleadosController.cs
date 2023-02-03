using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContratacionEmpleados.Models.ViewModels;
using ContratacionEmpleados.Models;
using System.IO;
using System.Web.Helpers;

namespace ContratacionEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        bd_PruebasEntities context = new bd_PruebasEntities();
        public ActionResult Index()
        {
            
            using (bd_PruebasEntities db = new bd_PruebasEntities())
            {
                var lista = (from a in db.Empleados
                             select new ListarEmpleado_VM
                             {
                                 IdEmpleado = a.IdEmpleado,
                                 Codigo = a.Codigo,
                                 Nombres = a.Nombres,
                                 Apellidos = a.Apellidos,
                                 Genero = a.Genero,
                                 TelefonoPersonal = a.TelefonoPersonal,
                                 EmailPersonal = a.EmailPersonal,
                                 TipoSangre = a.TipoSangre,
                                 //Fotografia = a.Fotografia
                             }).ToList();

                return View(lista);
            };


            
        }

       

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Models.ViewModels.ListarEmpleado_VM listarEmpleado_VM, HttpPostedFileBase file) {
            string rutaFotografia = string.Empty;
          
            try
            {
                if (file != null)
                {
                    rutaFotografia =  listarEmpleado_VM.Codigo + DateTime.Now.ToString("yyyyMMddHHmmss") +  file.FileName;
                    string path = Path.Combine(Server.MapPath("~/Imagenes"),  Path.GetFileName(rutaFotografia));
                    file.SaveAs(path);

                }
                ViewBag.FileStatus = "File uploaded successfully.";

                Empleados e = new Empleados();
                e.Codigo = listarEmpleado_VM.Codigo;
                e.Nombres = listarEmpleado_VM.Nombres;
                e.Apellidos = listarEmpleado_VM.Apellidos;
                e.TelefonoPersonal = listarEmpleado_VM.TelefonoPersonal;
                e.EmailPersonal = listarEmpleado_VM.EmailPersonal;
                e.Genero = listarEmpleado_VM.Genero;
                e.Fotografia = "/" + rutaFotografia;
                e.TipoSangre = listarEmpleado_VM.TipoSangre;                
                context.Empleados.Add(e);
                context.SaveChanges();
                return Redirect("~/Empleados/");
            }
            catch (Exception e)
            {

            };
                 
          
               
            

                return View();
        }

        
        public ActionResult Editar(int id)
        {
            EditarEmpleado_VM context = new EditarEmpleado_VM();
            using (bd_PruebasEntities db = new bd_PruebasEntities())
            {
                var e = db.Empleados.Find(id);
                
                context.Codigo = e.Codigo;
                context.Nombres = e.Nombres;
                context.Apellidos = e.Apellidos;
                context.TelefonoPersonal = e.TelefonoPersonal;
                context.EmailPersonal = e.EmailPersonal;
                context.Genero = e.Genero;
                context.TipoSangre = e.TipoSangre;
                context.Fotografia = e.Fotografia;
                context.IdEmpleado = e.IdEmpleado;
                
            };
            return View(context);

        }

        [HttpPost]
        public ActionResult Editar(EditarEmpleado_VM context, HttpPostedFileBase file)
        {
            
            try
            {
                
                

                using (bd_PruebasEntities db = new bd_PruebasEntities())
                {
                    string rutaFotografia = string.Empty;
                    var e = db.Empleados.Find(context.IdEmpleado);
                    if (file != null)
                    {
                        rutaFotografia = context.Codigo + DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName;
                        string path = Path.Combine(Server.MapPath("~/Imagenes"), Path.GetFileName(rutaFotografia));
                        file.SaveAs(path);
                    }                      

                    e.Codigo = context.Codigo;
                    e.Nombres = context.Nombres;
                    e.Apellidos = context.Apellidos;
                    e.TelefonoPersonal = context.TelefonoPersonal;
                    e.EmailPersonal = context.EmailPersonal;
                    e.Genero = context.Genero;
                    e.TipoSangre = context.TipoSangre;
                    e.Fotografia = "/" + rutaFotografia;
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

        
        public ActionResult Eliminar(int id)
        {
            EditarEmpleado_VM context = new EditarEmpleado_VM();
            using (bd_PruebasEntities db = new bd_PruebasEntities())
            {
                
                var e = db.Empleados.Find(id);
                db.Empleados.Remove(e);
                db.SaveChanges();
                
            };
            return Redirect("~/Empleados/");

        }

    }
}