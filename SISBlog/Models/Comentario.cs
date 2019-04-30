using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SISBlog.Models
{
    public class Comentario
    {
        public Comentario()
        {

        }

        public Comentario(DataRow row)
        {
            try
            {
                this.Id_comentario = Convert.ToInt32(row["Id_comentario"]);
                this.Persona = new Persona()
                {
                    Id_persona = Convert.ToInt32(row["Id_persona"]),
                    Nombre_persona = Convert.ToString(row["Nombre_persona"]),
                    Correo_electronico = Convert.ToString(row["Correo_electronico"])
                };
                this.Entrada = new Entradas()
                {
                    Id_entrada = Convert.ToInt32(row["Id_entrada"])
                };
                this.Descripcion = Convert.ToString(row["Descripcion"]);
                DateTime fecha = Convert.ToDateTime(row["Fecha"]);
                string hora = Convert.ToString(row["Hora"]);
                DateTime horaModificada = DateTime.ParseExact(hora,
                    "HH:mm:ss.fffffff", null, System.Globalization.DateTimeStyles.None);
                this.Fecha = fecha.ToLongDateString();
                this.Hora = horaModificada.ToLongTimeString();
            }
            catch (Exception ex)
            {

            }
        }

        public Comentario(DataTable dt, int fila)
        {
            try
            {
                this.Id_comentario = Convert.ToInt32(dt.Rows[fila]["Id_comentario"]);
                this.Persona = new Persona()
                {
                    Id_persona = Convert.ToInt32(dt.Rows[fila]["Id_persona"]),
                    Nombre_persona = Convert.ToString(dt.Rows[fila]["Nombre_persona"]),
                    Correo_electronico = Convert.ToString(dt.Rows[fila]["Correo_electronico"])
                };
                this.Entrada = new Entradas()
                {
                    Id_entrada = Convert.ToInt32(dt.Rows[fila]["Id_entrada"])
                };
                this.Descripcion = Convert.ToString(dt.Rows[fila]["Descripcion"]);
                DateTime fecha = Convert.ToDateTime(dt.Rows[fila]["Fecha"]);
                string hora = Convert.ToString(dt.Rows[fila]["Hora"]);
                DateTime horaModificada = DateTime.ParseExact(hora,
                    "HH:mm:ss.fffffff", null, System.Globalization.DateTimeStyles.None);
                this.Fecha = fecha.ToLongDateString();
                this.Hora = horaModificada.ToLongTimeString();

            }
            catch (Exception)
            {

            }
        }

        private int _id_comentario;
        private Persona _persona;
        private Entradas _entrada;
        private string _descripcion;
        private string _fecha;
        private string _hora;

        public int Id_comentario { get => _id_comentario; set => _id_comentario = value; }
        public Persona Persona { get => _persona; set => _persona = value; }
        public Entradas Entrada { get => _entrada; set => _entrada = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public string Hora { get => _hora; set => _hora = value; }
    }
}