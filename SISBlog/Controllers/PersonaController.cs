using CapaNegocio;
using System;
using System.Data;
using System.Web.Mvc;

namespace SISBlog.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult IniciarSesion()
        {
            TempData["MensajeOk"] = "NO";
            return View();
        }

        public ActionResult Login(FormCollection form)
        {
            TempData["MensajeOk"] = "NO";
            if (ModelState.IsValid && form.Count > 0)
            {
                string rpta;
                try
                {
                    DataTable tablePersona = NPersonas.BuscarPersonas("LOGIN",
                        Convert.ToString(form["correo"]),
                        Convert.ToString(form["pass"]), out rpta);
                    if (rpta.Equals("OK") & tablePersona != null)
                    {
                        Session["NombreUsuario"] = Convert.ToString(tablePersona.Rows[0]["Nombre_persona"]);
                        Session["TipoUsuario"] = Convert.ToString(tablePersona.Rows[0]["Tipo_persona"]);
                        TempData["MensajeOk"] = "OK";
                        return View("../Home/PanelControl");
                    }
                    else
                    {
                        TempData["MensajeOk"] = "NO EXISTE";
                        throw new Exception(rpta);
                    }
                }
                catch (Exception ex)
                {
                    return View("../Persona/IniciarSesion");
                }
            }

            return View("../Persona/IniciarSesion");
        }
    }
}