using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsecordLogin.Models
{
    public class Nacionalidades
    {
        [Key]
        public int NacionalidadID { get; set; }
        public string Nombre_nacionalidad { get; set; }

        public virtual ICollection<Clientes> Cliente { get; set; }
    }
}