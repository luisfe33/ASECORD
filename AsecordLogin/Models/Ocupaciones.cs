using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsecordLogin.Models
{
    public class Ocupaciones
    {
        [Key]
        public int OcupacionID { get; set; }
        public string Nombre_ocupacion { get; set; }

        public virtual ICollection<Clientes> Cliente { get; set; }
    }
}