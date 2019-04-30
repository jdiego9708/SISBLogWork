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
        public ActionResult VerEntradas(string tipo_busqueda, string texto_busqueda, bool isEditar = false)
        {
            //Si el tipo de búsqueda es null asignamos el tipo de búsqueda
            if (tipo_busqueda == null)
            {
                tipo_busqueda = "COMPLETO";
                texto_busqueda = "";
            }

            List<Entradas> listEntradas = new List<Entradas>();
            DataTable tablaEntradas =
                NEntradas.BuscarEntradas(tipo_busqueda, texto_busqueda, out string rpta);
            if (tablaEntradas != null & rpta.Equals("OK"))
            {
                foreach (DataRow row in tablaEntradas.Rows)
                {
                    Entradas entrada = new Entradas(row);
                    entrada.IsEditar = isEditar;
                    listEntradas.Add(entrada);
                }
            }

            return View(listEntradas);
        }

        public ActionResult InsertarEntrada(Entradas entradaEditar = null)
        {
            if (entradaEditar != null)
            {
                if (entradaEditar.IsEditar)
                {
                    return View(entradaEditar);
                }
                else
                {
                    return View(new Entradas() { IsEditar = false });
                }

            }
            else
            {
                return View(new Entradas() { IsEditar = false });
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
                    bool isEditar = Convert.ToBoolean(form["isEditar"]);
                    if (isEditar)
                    {
                        id_entrada = Convert.ToInt32(form["Id_entrada"]);
                        rpta = NEntradas.EditarEntrada(id_entrada, 2022,
                        Convert.ToString(form["Titulo_entrada"]),
                        Convert.ToString(form["Descripcion_entrada"]));
                    }
                    else
                    {
                        rpta = NEntradas.InsertarEntrada(2022,
                        Convert.ToString(form["Titulo_entrada"]),
                        Convert.ToString(form["Descripcion_entrada"]), out id_entrada);
                    }

                    if (rpta.Equals("OK"))
                    {
                        ViewBag.Insert = rpta;
                        //TempData["MensajeOk"] = "OK";
                        return View("InsertarEntrada", new Entradas());
                    }
                    else
                    {
                        throw new Exception(rpta);
                    }
                }
                catch (Exception)
                {
                    return View("InsertarEntrada", new Entradas());
                }
            }
            else
            {
                return View("InsertarEntrada", new Entradas());
            }
        }

        public ActionResult ProfileEntrada(Entradas entradaEditar)
        {
            List<Comentario> comentarios = new List<Comentario>();
            DataTable dtComentarios =
                NComentarios.BuscarComentarios("COMPLETO ID ENTRADA", entradaEditar.Id_entrada.ToString(),
                out string rpta);
            if (dtComentarios != null)
            {
                foreach (DataRow row in dtComentarios.Rows)
                {
                    Comentario comentario = new Comentario(row);
                    comentarios.Add(comentario);
                }
                entradaEditar.Comentarios = comentarios;
            }

            return View(entradaEditar);
        }

    }
}