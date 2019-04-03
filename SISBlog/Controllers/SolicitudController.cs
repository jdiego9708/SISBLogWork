using CapaNegocio;
using System;
using System.Web.Mvc;
using System.Web.UI;

namespace SISBlog.Controllers
{
    public class SolicitudController : Controller
    {
        // GET: Solicitud
        public ActionResult VerNuevaSolicitud()
        {
            return View();
        }

        public JavaScriptResult InsertarNuevaSolicitud(FormCollection form)
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
                        return JavaScript ("alert("+ "Solicitud enviada correctamente, Número de solicitud" + 
                            id_solicitud.ToString() +");");
                    }
                    else
                    {
                        throw new Exception(rpta);
                    }
                }
                catch (Exception)
                {
                    return JavaScript("alert(" + "Hubo un error al procesar la solicitud "+ ");");
                }
            }
            return JavaScript("alert(" + "Hubo un error al procesar la solicitud " + ");");
            //return View("VerNuevaSolicitud");
        }
    }
}