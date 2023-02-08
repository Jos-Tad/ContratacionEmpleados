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
                var lista = (from a in db.Empleados /*where a.EstadoFila = true*/
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
            Lista();
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
                //e.EstadoFila = true;
                context.Empleados.Add(e);
                context.SaveChanges();
                return Redirect("~/Empleados/Crear");
            }
            catch (Exception e)
            {

            };
                 
          
               
            

                return View();
        }

        
        public ActionResult Editar(int id)
        {

            Lista();
            EditarEmpleado_VM context = new EditarEmpleado_VM();
           
            using (bd_PruebasEntities db = new bd_PruebasEntities())
            {
                var e = db.Empleados.Find(id);
                Contrato c = db.Contrato.Where(p => p.IdEmpleado == id && p.EstadoFila==true).FirstOrDefault();

                context.Codigo = e.Codigo;
                context.Nombres = e.Nombres;
                context.Apellidos = e.Apellidos;
                context.TelefonoPersonal = e.TelefonoPersonal;
                context.EmailPersonal = e.EmailPersonal;
                context.Genero = e.Genero;
                context.TipoSangre = e.TipoSangre;
                context.Fotografia = e.Fotografia;
                

                context.IdArea = c.IdArea;
                context.IdEmpleado = c.IdEmpleado;
                context.IdCargo = c.IdCargo;
                context.TipoContrato = c.TipoContrato;
                context.Salario = c.Salario;
                context.FechaFin = c.FechaFin;
                context.FechaInicio = c.FechaInicio;
                context.IdContrato = c.IdContrato;



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
                    //variable para guardar file con ruta
                    string rutaFotografia = string.Empty;
                    var e = db.Empleados.Find(context.IdEmpleado);
                    var c = db.Contrato.Find(context.IdContrato);
                    if (file != null)
                    {
                        rutaFotografia = context.Codigo + DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName;
                        string path = Path.Combine(Server.MapPath("~/Imagenes"), Path.GetFileName(rutaFotografia));
                        file.SaveAs(path);
                    }
                    //campos de empleado
                    //e.IdEmpleado = context.IdEmpleado;
                    e.Codigo = context.Codigo;
                    e.Nombres = context.Nombres;
                    e.Apellidos = context.Apellidos;
                    e.TelefonoPersonal = context.TelefonoPersonal;
                    e.EmailPersonal = context.EmailPersonal;
                    e.Genero = context.Genero;
                    e.TipoSangre = context.TipoSangre;
                    e.Fotografia = "/" + rutaFotografia;
                    //campos de contrato
                    //c.IdEmpleado = context.IdEmpleado;
                    c.IdCargo = context.IdCargo;
                    c.IdArea = context.IdArea;
                    c.FechaInicio = context.FechaInicio;
                    c.FechaFin = context.FechaFin;
                    c.TipoContrato = context.TipoContrato;
                    c.Salario = context.Salario;
                    c.EstadoFila = true;
                    //c.IdContrato = context.IdContrato;
                    //modificar
                    db.Entry(e).State = System.Data.Entity.EntityState.Modified;                    
                    db.Entry(c).State = System.Data.Entity.EntityState.Modified;
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
                //e.EstadoFila = false;
                db.Empleados.Remove(e);
                db.SaveChanges();
                
            };
            return Redirect("~/Empleados/");

        }

        public void Lista()
        {

            List<ListarEmpleado_VM> lst = null;
            List<Cargo_VM> lst2 = null;
            List<Area_VM> lst3 = null;
            List<TipoContrato_VM> lst4 = null;
            using (Models.bd_PruebasEntities db = new Models.bd_PruebasEntities())
            {
                lst = (from d in context.Empleados
                       select new ListarEmpleado_VM
                       {
                           IdEmpleado = d.IdEmpleado,
                           Nombres = d.Nombres
                       }).ToList();
                lst2 = (from d in context.Cargos
                        select new Cargo_VM
                        {
                            IdCargo = d.IdCargo,
                            NombreCargo = d.NombreCargo
                        }).ToList();
                lst3 = (from d in context.Areas
                        select new Area_VM
                        {
                            IdArea = d.IdArea,
                            NombreArea = d.NombreArea
                        }).ToList();
                lst4 = (from d in context.TipoContrato
                        select new TipoContrato_VM
                        {
                            IdTipoContrato = d.IdTipoContrato,
                            NombreTipoContrato = d.NombreTipoContrato
                        }).ToList();

            }
            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombres.ToString(),
                    Value = d.IdEmpleado.ToString(),
                    Selected = false
                };
            });
            ViewBag.items = items;
            List<SelectListItem> items2 = lst2.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.NombreCargo.ToString(),
                    Value = d.IdCargo.ToString(),
                    Selected = false
                };
            });
            ViewBag.items2 = items2;
            List<SelectListItem> items3 = lst3.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.NombreArea.ToString(),
                    Value = d.IdArea.ToString(),
                    Selected = false
                };
            });
            ViewBag.items3 = items3;
            List<SelectListItem> items4 = lst4.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.NombreTipoContrato.ToString(),
                    Value = d.IdTipoContrato.ToString(),
                    Selected = false
                };
            });
            ViewBag.items4 = items4;

        }
    }
}