using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {
        //Obtener la cadena de conexión
        public static string ObtenerCadenaDeConexion(string Nombre_cadena_de_conexion, string tipo_dato)
        {
            string cadena = "";
            // se obtienen las conexiones
            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;

            //si existe por lo menos una conexión continuamos
            if (connections.Count != 0)
            {
                //Recorremos las conexiones existentes
                foreach (ConnectionStringSettings connection in connections)
                {
                    //asignamos el nombre
                    string name = connection.Name;
                    //obtenemos el proveedor, solo por demostración, no lo utilizaremos ni nada.
                    string provider = connection.ProviderName;
                    //obtenemos la cadena
                    string connectionString = connection.ConnectionString;

                    //comparamos el nombre al de nuestro atributo de la clase para verificar si es la cadena
                    //de conexión que modificaremos
                    if (name.Equals(Nombre_cadena_de_conexion) && tipo_dato.Equals("COMPLETA"))
                    {
                        cadena = connectionString;
                        break;
                    }
                    else if (name.Equals(Nombre_cadena_de_conexion) && tipo_dato.Equals("NOMBRE SERVIDOR"))
                    {
                        cadena = name;
                        break;
                    }
                    else if (name.Equals(Nombre_cadena_de_conexion) && tipo_dato.Equals("COMPLETA SIN PASS"))
                    {

                    }
                }
            }
            else
            {
                Console.WriteLine("No existe la conexión");
            }
            return cadena;
        }

        public static string Cn = ObtenerCadenaDeConexion("conexionLocalBD", "COMPLETA");
    }
}
