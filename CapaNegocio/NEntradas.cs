using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaNegocio
{
    public class NEntradas
    {
        public static string InsertarEntrada(int id_persona, string titulo_entrada, string descripcion,
            out int id_entrada)
        {
            DEntradas dEntradas = new DEntradas();
            return dEntradas.InsertarEntrada(id_persona, titulo_entrada, descripcion, out id_entrada);
        }

        public static string EditarEntrada(int id_entrada, int id_persona, string titulo_entrada, string descripcion)
        {
            DEntradas dEntradas = new DEntradas();
            return dEntradas.Editar_entrada(id_entrada, id_persona, titulo_entrada, descripcion);
        }

        public static DataTable BuscarEntradas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DEntradas dEntradas = new DEntradas();
            return dEntradas.BuscarEntradas(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
