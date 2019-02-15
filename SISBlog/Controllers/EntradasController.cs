using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaNegocio;
using SISBlog.Models;

namespace SISBlog.Controllers
{
    public class EntradasController : Controller
    {
        // GET: Entradas
        public ActionResult VerEntradas()
        {
            List<Entradas> listEntradas = new List<Entradas>();
            string rpta;
            DataTable tablaEntradas =
                NEntradas.BuscarEntradas("COMPLETO", "", out rpta);
            if (tablaEntradas != null & rpta.Equals("OK"))
            {
                foreach (DataRow row in tablaEntradas.Rows)
                {
                    Entradas entrada = new Entradas();
                    entrada.Id_entrada = Convert.ToInt32(row["Id_entrada"]);
                    entrada.Id_persona = Convert.ToInt32(row["Id_persona"]);
                    entrada.Nombre_persona = Convert.ToString(row["Nombre_persona"]);
                    entrada.Correo_electronico = Convert.ToString(row["Correo_electronico"]);
                    DateTime fecha = Convert.ToDateTime(row["Fecha_publicacion"]);
                    entrada.Fecha_publicacion = fecha.ToLongDateString();
                    //DateTime hora = Convert.ToDateTime(row["Hora_publicacion"]);
                    entrada.Hora_publicacion = Convert.ToString(row["Hora_publicacion"]);
                    entrada.Titulo_entrada = Convert.ToString(row["Titulo_entrada"]);
                    entrada.Descripcion_entrada = Convert.ToString(row["Descripcion_entrada"]);
                    listEntradas.Add(entrada);
                }
            }

            return View(listEntradas);
        }

        public ActionResult InsertarEntrada()
        {
            return View();
        }

        public ActionResult Insert()
        {
            if (ModelState.IsValid)
            {
                string rpta;
                try
                {
                    int id_entrada;
                    rpta = NEntradas.InsertarEntrada(2022,
                        Convert.ToString(Request.Form["txtTitulo"]),
                        Convert.ToString(Request.Form["txtDescripcion"]), out id_entrada);
                    if (rpta.Equals("OK"))
                    {
                        return View("VerEntradas");
                    }
                    else
                    {
                        throw new Exception(rpta);
                    }
                }
                catch (Exception ex)
                {
                    return View("VerEntradas");
                }
            }
            else
            {
                return View("VerEntradas");
            }
        }
    }
}