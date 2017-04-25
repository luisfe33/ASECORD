using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsecordLogin.Models
{
    public class Recibos
    {
        [Key]
        public int ReciboID { get; set; }
        public Clientes Cliente { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string Fecha { get; set; }
        public string Concepto { get; set; }
        public decimal Valor { get; set; }
        [Display(Name = "Forma de Pago")]
        public int Forma_pago { get; set; }
        public string Comentario { get; set; }
        public int Estatus { get; set; }

        //   public virtual Clientes Cliente { get; set; }
    }
}