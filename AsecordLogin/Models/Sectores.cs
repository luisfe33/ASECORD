using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsecordLogin.Models
{
    public class Sectores
    {
        [Key]
        public int SectorID { get; set; }
        public string Nombre_sector { get; set; }

        public virtual Ciudades Ciudad { get; set; }
    }
}