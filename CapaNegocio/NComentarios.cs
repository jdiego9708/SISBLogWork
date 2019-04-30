using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NComentarios
    {
        public static string InsertarComentarios(out int id_comentario, int id_persona, int id_entrada, string descripcion)
        {
            DComentarios dComentarios = new DComentarios();
            return dComentarios.InsertarComentario(out id_comentario, id_persona, id_entrada, descripcion);
        }

        public static string EditarComentarios(int id_comentario, int id_persona, int id_entrada, string descripcion)
        {
            DComentarios dComentarios = new DComentarios();
            return dComentarios.EditarComentario(id_comentario, id_persona, id_entrada, descripcion);
        }

        public static DataTable BuscarComentarios(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DComentarios dComentarios = new DComentarios();
            return dComentarios.BuscarComentarios(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
