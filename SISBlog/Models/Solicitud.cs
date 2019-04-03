using System;
using System.Data;

namespace SISBlog.Models
{
    public class Solicitud
    {
        public Solicitud()
        {

        }

        public Solicitud(DataRow row)
        {
            this.Id_solicitud = Convert.ToInt32(row["Id_solicitud"]);
            this.Fecha_solicitud = Convert.ToDateTime(row["Fecha_solicitud"]);
            this.Hora_solicitud = Convert.ToString(row["Hora_solicitud"]);
            int id_persona = Convert.ToInt32(row["Id_persona"]);
            string correo = Convert.ToString(row["Correo_electronico"]);
            string nombre = Convert.ToString(row["Nombre_persona"]);
            this.Persona =
                new Persona() { Id_persona = id_persona, Correo_electronico = correo, Nombre_persona = nombre };
            this.Descripcion = Convert.ToString(row["Descripcion"]);
            this.Estado = Convert.ToString(row["Estado"]);
        }

        public Solicitud(DataTable dtEntradas, int fila)
        {
            this.Id_solicitud = Convert.ToInt32(dtEntradas.Rows[fila]["Id_solicitud"]);
            this.Fecha_solicitud = Convert.ToDateTime(dtEntradas.Rows[fila]["Fecha_solicitud"]);
            this.Hora_solicitud = Convert.ToString(dtEntradas.Rows[fila]["Hora_solicitud"]);
            int id_persona = Convert.ToInt32(dtEntradas.Rows[fila]["Id_persona"]);
            string correo = Convert.ToString(dtEntradas.Rows[fila]["Correo_electronico"]);
            string nombre = Convert.ToString(dtEntradas.Rows[fila]["Nombre_persona"]);
            this.Persona =
                new Persona() { Id_persona = id_persona, Correo_electronico = correo, Nombre_persona = nombre };
            this.Descripcion = Convert.ToString(dtEntradas.Rows[fila]["Descripcion"]);
            this.Estado = Convert.ToString(dtEntradas.Rows[fila]["Estado"]);
        }

        private int _id_solicitud;
        private DateTime _fecha_solicitud;
        private string _hora_solicitud;
        private Persona _persona;
        private string _descripcion;
        private string _estado;

        public int Id_solicitud { get => _id_solicitud; set => _id_solicitud = value; }
        public DateTime Fecha_solicitud { get => _fecha_solicitud; set => _fecha_solicitud = value; }
        public string Hora_solicitud { get => _hora_solicitud; set => _hora_solicitud = value; }
        public Persona Persona { get => _persona; set => _persona = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}