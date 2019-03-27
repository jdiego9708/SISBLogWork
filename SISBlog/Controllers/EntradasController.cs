using CapaNegocio;
using SISBlog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace SISBlog.Controllers
{
    public class EntradasController : Controller
    {

        // GET: Entradas
        public ActionResult VerEntradas(bool isEditar = false)
        {
            ViewBag.isEditar = isEditar;

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

        public ActionResult InsertarEntrada(Entradas entradaEditar)
        {
            if (entradaEditar != null)
            {

                ViewBag.isEditar = true;
                return View(entradaEditar);
            }
            else
            {
                ViewBag.isEditar = false;
                return View();
            }
        }

        public ActionResult Insert(FormCollection form)
        {
            if (ModelState.IsValid && form.Count > 0)
            {
                string rpta;
                try
                {
                    int id_entrada;
                    rpta = NEntradas.InsertarEntrada(2022,
                        Convert.ToString(form["Titulo_entrada"]),
                        Convert.ToString(form["Descripcion_entrada"]), out id_entrada);
                    if (rpta.Equals("OK"))
                    {
                        ViewBag.Insert = rpta;
                        //TempData["MensajeOk"] = "OK";
                        return View("InsertarEntrada");
                    }
                    else
                    {
                        throw new Exception(rpta);
                    }
                }
                catch (Exception)
                {
                    return View("InsertarEntrada");
                }
            }
            else
            {
                return View("InsertarEntrada");
            }
        }

    }
}