using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsecordLogin.Models
{
    public class Ciudades
    {

        [Key]
        public int CiudadID { get; set; }
        public string Nombre_ciudad { get; set; }


        public virtual Provincias Provincia { get; set; }
        public virtual ICollection<Sectores> Sectores { get; set; }

    }
}