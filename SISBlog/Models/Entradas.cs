using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISBlog.Models
{
    public class Entradas
    {
        private int _id_entrada;
        private int _id_persona;
        private string _nombre_persona;
        private string _correo_electronico;
        private DateTime _fecha_publicacion;
        private DateTime _hora_publicacion;
        private string _titulo_entrada;
        private string _descripcion_entrada;

        [Display(Name = "Número de entrada")]
        public int Id_entrada { get => _id_entrada; set => _id_entrada = value; }
        [Display(Name = "Id persona")]
        public int Id_persona { get => _id_persona; set => _id_persona = value; }
        [Display(Name = "Nombre")]
        public string Nombre_persona { get => _nombre_persona; set => _nombre_persona = value; }
        [Display(Name = "Correo electronico")]
        public string Correo_electronico { get => _correo_electronico; set => _correo_electronico = value; }
        [Display(Name = "Fecha")]
        public DateTime Fecha_publicacion { get => _fecha_publicacion; set => _fecha_publicacion = value; }
        [Display(Name = "Hora")]
        public DateTime Hora_publicacion { get => _hora_publicacion; set => _hora_publicacion = value; }
        [Display(Name = "Título")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Titulo_entrada { get => _titulo_entrada; set => _titulo_entrada = value; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Descripcion_entrada { get => _descripcion_entrada; set => _descripcion_entrada = value; }
    }
}