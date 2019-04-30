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
    public class ComentarioController : Controller
    {
        // GET: Comentario
        public ActionResult InsertarComentario(FormCollection form)
        {
            string rpta = "OK";
            string comentario = Convert.ToString(form["txtComentario"]);
            int id_entrada = Convert.ToInt32(form["Id_entrada"]);
            int id_persona = Convert.ToInt32(form["Id_persona"]);
            rpta = 
                NComentarios.InsertarComentarios(out int id_comentario, id_persona, id_entrada, comentario);
            if (rpta.Equals("OK"))
            {
                ViewBag.Insert = "OK";
            }

            return PartialView();
        }
    }
}