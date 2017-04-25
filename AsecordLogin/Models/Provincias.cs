using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsecordLogin.Models
{
    public class Provincias
    {
        [Key]
        public int ProvinciaID { get; set; }
        public string Nombre_provincia { get; set; }

        public virtual ICollection<Clientes> Cliente { get; set; }
        public virtual ICollection<Ciudades> Ciudad { get; set; }
    }
}