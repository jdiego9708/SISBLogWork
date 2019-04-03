using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SISBlog.Models
{
    public class Entradas
    {
        public Entradas ()
        {
            this.IsEditar = false;
        }

        public Entradas(DataRow row)
        {
            this.IsEditar = true;
            this.Id_entrada = Convert.ToInt32(row["Id_entrada"]);
            this.Id_persona = Convert.ToInt32(row["Id_persona"]);
            this.Nombre_persona = Convert.ToString(row["Nombre_persona"]);
            this.Correo_electronico = Convert.ToString(row["Correo_electronico"]);
            DateTime fecha = Convert.ToDateTime(row["Fecha_publicacion"]);
            this.Fecha_publicacion = fecha.ToLongDateString();
            //DateTime hora = Convert.ToDateTime(row["Hora_publicacion"]);
            this.Hora_publicacion = Convert.ToString(row["Hora_publicacion"]);
            this.Titulo_entrada = Convert.ToString(row["Titulo_entrada"]);
            this.Descripcion_entrada = Convert.ToString(row["Descripcion_entrada"]);
        }

        public Entradas(DataTable dtEntradas, int fila)
        {
            this.IsEditar = true;
            this.Id_entrada = Convert.ToInt32(dtEntradas.Rows[fila]["Id_entrada"]);
            this.Id_persona = Convert.ToInt32(dtEntradas.Rows[fila]["Id_persona"]);
            this.Nombre_persona = Convert.ToString(dtEntradas.Rows[fila]["Nombre_persona"]);
            this.Correo_electronico = Convert.ToString(dtEntradas.Rows[fila]["Correo_electronico"]);
            DateTime fecha = Convert.ToDateTime(dtEntradas.Rows[fila]["Fecha_publicacion"]);
            this.Fecha_publicacion = fecha.ToLongDateString();
            //DateTime hora = Convert.ToDateTime(row["Hora_publicacion"]);
            this.Hora_publicacion = Convert.ToString(dtEntradas.Rows[fila]["Hora_publicacion"]);
            this.Titulo_entrada = Convert.ToString(dtEntradas.Rows[fila]["Titulo_entrada"]);
            this.Descripcion_entrada = Convert.ToString(dtEntradas.Rows[fila]["Descripcion_entrada"]);
        }

        private int _id_entrada;
        private int _id_persona;
        private string _nombre_persona;
        private string _correo_electronico;
        private string _fecha_publicacion;
        private string _hora_publicacion;
        private string _titulo_entrada;
        private string _descripcion_entrada;
        private bool _isEditar;


        [Display(Name = "Número de entrada")]
        public int Id_entrada { get => _id_entrada; set => _id_entrada = value; }
        [Display(Name = "Id persona")]
        public int Id_persona { get => _id_persona; set => _id_persona = value; }
        [Display(Name = "Nombre")]
        public string Nombre_persona { get => _nombre_persona; set => _nombre_persona = value; }
        [Display(Name = "Correo electronico")]
        public string Correo_electronico { get => _correo_electronico; set => _correo_electronico = value; }
        [Display(Name = "Fecha")]
        public string Fecha_publicacion { get => _fecha_publicacion; set => _fecha_publicacion = value; }
        [Display(Name = "Hora")]
        public string Hora_publicacion { get => _hora_publicacion; set => _hora_publicacion = value; }
        [Display(Name = "Título")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Titulo_entrada { get => _titulo_entrada; set => _titulo_entrada = value; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Descripcion_entrada { get => _descripcion_entrada; set => _descripcion_entrada = value; }
        public bool IsEditar { get => _isEditar; set => _isEditar = value; }
    }
}