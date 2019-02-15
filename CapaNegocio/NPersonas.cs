
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPersonas
    {
        public static string InsertarPersona(string nombre_persona, string tipo, string correo,
            out int id_persona)
        {
            DPersonas DPersonas = new DPersonas();
            return DPersonas.InsertarPersona(nombre_persona, tipo, correo, out id_persona);
        }

        public static string EditarPersona(int id_persona, string nombre_persona, string tipo, string correo)
        {
            DPersonas DPersonas = new DPersonas();
            return DPersonas.EditarPersona(id_persona, nombre_persona, tipo, correo);
        }

        public static DataTable BuscarPersonas(string tipo_busqueda, string texto_busqueda1, 
            string texto_busqueda2, out string rpta)
        {
            DPersonas DPersonas = new DPersonas();
            return DPersonas.BuscarPersonas(tipo_busqueda, texto_busqueda1, texto_busqueda2, out rpta);
        }
    }
}
