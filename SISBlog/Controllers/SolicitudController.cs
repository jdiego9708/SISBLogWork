using CapaNegocio;
using System;
using System.Web.Mvc;
using System.Web.UI;

namespace SISBlog.Controllers
{
    public class SolicitudController : Controller
    {
        public ActionResult ViewPartialMessage()
        {
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