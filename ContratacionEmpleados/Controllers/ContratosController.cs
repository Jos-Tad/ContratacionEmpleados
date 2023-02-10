using ContratacionEmpleados.Models;
using ContratacionEmpleados.Models.ViewModels;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ContratacionEmpleados.Controllers
{
    public class ContratosController : Controller
    {

        private readonly string connectionString = @"Data Source=192.168.20.62\SQL2019;Initial Catalog=bd_Pruebas;User ID=UsrIGC;Password=UsrIGC;MultipleActiveResultSets=True;Application Name=EntityFramework";
        

        bd_PruebasEntities context = new bd_PruebasEntities();
        // GET: Contratos
        [HttpGet]

        public ActionResult Listar()
        {
            using (bd_PruebasEntities db = new bd_PruebasEntities())
            {
                var lista = (from a in db.VW_Contrato
                             where a.EstadoFila == true
                             select new VwListarContrato
                             {
                                 Nombres = a.Nombres,
                                 Codigo = a.Codigo,
                                 FechaInicio = a.FechaInicio,
                                 FechaFin = a.FechaFin,
                                 NombreArea = a.NombreArea,
                                 NombreCargo = a.NombreCargo,
                                 NombreTipoContrato = a.NombreTipoContrato,
                                 Salario = a.Salario
                                 //Dias = a.Dias,
                                 
                             }).ToList();

                return View(lista);
            };


           
        }
        

        [HttpPost]
        public ActionResult Listar(DateTime fechai, DateTime fechaf)
        {
            List<VwListarContrato> dataList = new List<VwListarContrato>();
            


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("RP_Contrato_Filtro_Fecha", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FechaI", fechai);
                command.Parameters.AddWithValue("@FechaF", fechaf);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        VwListarContrato lista = new VwListarContrato();
                        lista.Nombres = reader.GetString(0);
                        lista.Codigo = reader.GetString(1);
                        lista.IdContrato = reader.GetInt32(2);
                        lista.EstadoFila = reader.GetBoolean(3);
                        lista.FechaInicio = reader.GetDateTime(4);
                        lista.FechaFin = reader.GetDateTime(5);
                        lista.Salario = reader.GetDouble(6);
                        lista.NombreArea = reader.GetString(7);
                        lista.NombreCargo = reader.GetString(8);
                        lista.NombreTipoContrato = reader.GetString(9);

                        dataList.Add(lista);
                    }
                }
               

                reader.Close();
            }

            return View(dataList);
        }

        public ActionResult Rpt_Contrato()
        {
            List<VwListarContrato> list = new List<VwListarContrato>();



            return View();

        }


        public ActionResult Crear()
        {

            
            return View();

        }

        [HttpPost]
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
                return Redirect("~/Empleados/");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }
        public ActionResult Editar(int id)
        {
            Contrato_VM context = new Contrato_VM();
            using (bd_PruebasEntities db = new bd_PruebasEntities())
            {

                

              
                    
                    var e = db.Contrato.Find(id);


                    context.IdEmpleado = e.IdEmpleado;
                    context.IdArea = e.IdArea;
                    context.IdCargo = e.IdCargo;
                    context.TipoContrato = e.TipoContrato;
                    context.Salario = e.Salario;
                    context.FechaFin = e.FechaFin;
                    context.FechaInicio = e.FechaInicio;
                    context.IdContrato = e.IdContrato;
                    //context.EstadoFila = e.EstadoFila;

                



            }




            return View(context);
        }

        [HttpPost]
        public ActionResult Editar(Contrato_VM context)
        {

            try
            {



                using (bd_PruebasEntities db = new bd_PruebasEntities())
                {

                    var e = db.Contrato.Find(context.IdContrato);

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

        public ActionResult Eliminar(int id)
        {
            Contrato_VM context = new Contrato_VM();
            using (bd_PruebasEntities db = new bd_PruebasEntities())
            {

                var e = db.Contrato.Find(id);
                e.EstadoFila = false;
                db.SaveChanges();

            };
            return Redirect("~/Empleados/");

        }



       
      
    }
}