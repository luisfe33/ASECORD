using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsecordLogin.Models
{
    public class Citas_locales
    {
        [Key]
        public int CitaID { get; set; }
        public Clientes Cliente { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Tipo { get; set; }
        public string Comentario { get; set; }
        public int Estatus { get; set; }
    }
}