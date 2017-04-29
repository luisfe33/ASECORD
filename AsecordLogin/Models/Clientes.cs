using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsecordLogin.Models
{
    public class Clientes
    {
        [Key]
        [Display(Name = "ID")]
        public int CLienteID { get; set; }
        [Display(Name = "Nombres")]
        public string Nombre { get; set; }
        [Display(Name = "Apellidos")]
        public string Apellido { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string Fecha_nacimiento { get; set; }
        [Display(Name = "Cedula")]
        public string Cedula { get; set; }
        public string Sexo { get; set; }
        [Display(Name = "Estado Civil")]
        public string Estado_civil { get; set; }
        public string Direccion { get; set; }
        public Ciudades Ciudad { get; set; }
        public Sectores Sector { get; set; }
        public string Email { get; set; }
        [Display(Name = "Fecha de Ingreso")]
        public string Fecha_ingreso { get; set; }
        [Display(Name = "Numero de Pasaporte")]
        public string Pasaporte { get; set; }
        public string Comentario { get; set; }
        [Display(Name = "Telefono Casa")]
        public string Tel_1 { get; set; }
        [Display(Name = "Telefono Celular")]
        public string Tel_2 { get; set; }
        [Display(Name = "Telefono Oficina")]
        public string Tel_3 { get; set; }
        public string Ocupacion { get; set; }
        [Display(Name = "Nombre de la Empresa")]
        public string Empresa_Nombre { get; set; }
        [Display(Name = "Direccion de la Empresa")]
        public string Empresa_Dir { get; set; }
        [Display(Name = "Telefono Empresa")]
        public string Empresa_Tel { get; set; }
        [Display(Name = "Funciones")]
        public string Empresa_Labor { get; set; }

        [Display(Name = "Pago")]
        public string TipoDePago { get; set; }
        [Display(Name = "Perfil")]
        public string Estatus_1 { get; set; }
        [Display(Name = "Impuesto")]
        public string Estatus_2 { get; set; }
        [Display(Name = "Citas")]
        public string Estatus_3 { get; set; }
        [Display(Name = "Documentacion Requerida")]
        public string Estatus_4 { get; set; }
        [Display(Name = "DS-160")]
        public string Estatus_5 { get; set; }
        [Display(Name ="Codigo DS-160")]
        public string Codigo_DS { get; set; }
        [Display(Name = "Confirmacion de Citas")]
        public string Estatus_6 { get; set; }
        [Display(Name = "Confirmacion DS-160")]
        public string Estatus_7 { get; set; }
        [Display(Name = "Formulario Detallado")]
        public string Estatus_8 { get; set; }
        [Display(Name = "Pre-Entrevista")]
        public string Estatus_9 { get; set; }
        [Display(Name = "Estatus Final")]
        public string Estatus_10 { get; set; }

        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }
        public string P4 { get; set; }
        public string P5 { get; set; }
        public string P6 { get; set; }
        public string P7 { get; set; }
        public string P8 { get; set; }
        public string P9 { get; set; }
        public string P10 { get; set; }


        public virtual ICollection<Recibos> Recibos { get; set; }

        //public virtual Ocupaciones Ocupacion { get; set; }
        public virtual Nacionalidades Nacionalidad { get; set; }
        public virtual Provincias Provincia { get; set; }

    }
}