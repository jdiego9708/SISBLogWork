using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NSolicitudes
    {
        public static string InsertarSolicitudes(out int id_solicitud, string descripcion,
             string nombre, string correo)
        {
            DSolicitudes DSolicitudes = new DSolicitudes();
            return DSolicitudes.InsertarSolicidud(out id_solicitud, descripcion, nombre, correo);
        }

        public static string ActualizarSolicitudes(int id_solicitud, string estado)
        {
            DSolicitudes DSolicitudes = new DSolicitudes();
            return DSolicitudes.ActualizarSolicidud(id_solicitud, estado);
        }

        public static DataTable BuscarSolicitudes(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DSolicitudes DSolicitudes = new DSolicitudes();
            return DSolicitudes.BuscarSolicitudes(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
