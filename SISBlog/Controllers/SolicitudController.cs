using CapaNegocio;
using SISBlog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using System.Web.UI;

namespace SISBlog.Controllers
{
    public class SolicitudController : Controller
    {
        public ActionResult VerSolicitudes()
        {
            try
            {
                DataTable dtSolicitudes =
                    NSolicitudes.BuscarSolicitudes("COMPLETO", "", out string rpta);
                if (dtSolicitudes != null)
                {
                    List<Solicitud> solicitudes = new List<Solicitud>();
                    foreach(DataRow row in dtSolicitudes.Rows)
                    {
                        solicitudes.Add(new Solicitud(row));
                    }
                    return View(solicitudes);
                }
            }
            catch (Exception)
            {
                return View();
            }
            return View();
        }

        // GET: Solicitud
        public ActionResult VerNuevaSolicitud()
        {
            return View();
        }

        public ActionResult InsertarNuevaSolicitud(FormCollection form)
        {
            if (ModelState.IsValid && form.Count > 0)
            {
                string rpta;
                try
                {
                    rpta = NSolicitudes.InsertarSolicitudes(out int id_solicitud,
                        Convert.ToString(form["Descripcion"]), Convert.ToString(form["Persona.Nombre_persona"]),
                        Convert.ToString(form["Persona.Correo_electronico"]));
                    if (rpta.Equals("OK"))
                    {
                        ViewBag.Insert = rpta;
                        return View("VerNuevaSolicitud");
                    }
                    else
                    {
                        throw new Exception(rpta);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Insert = ex.Message;
                    return View("VerNuevaSolicitud");
                }
            }
            return View("VerNuevaSolicitud");
            //return View("VerNuevaSolicitud");
        }
    }
}