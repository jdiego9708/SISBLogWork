using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISBlog.Models
{
    public class Persona
    {
        private int _id_persona;
        private string _fecha_ingreso;
        private string _nombre_persona;
        private string _tipo_persona;
        private string _correo_electronico;

        [Display(Name = "Id persona")]
        public int Id_persona { get => _id_persona; set => _id_persona = value; }
        [Display(Name = "Fecha ingreso")]
        public string Fecha_ingreso { get => _fecha_ingreso; set => _fecha_ingreso = value; }
        [Display(Name = "Nombre")]
        public string Nombre_persona { get => _nombre_persona; set => _nombre_persona = value; }
        [Display(Name = "Tipo")]
        public string Tipo_persona { get => _tipo_persona; set => _tipo_persona = value; }
        [Display(Name = "Correo electrónico")]
        public string Correo_electronico { get => _correo_electronico; set => _correo_electronico = value; }
    }
}