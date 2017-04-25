namespace AsecordLogin.DAL
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class AsesoriaContext : DbContext
    {
        public AsesoriaContext()
            : base("AsecordLogin")
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Citas_consulares> Citas_Consulares { get; set; }
        public DbSet<Citas_locales> Citas_locales { get; set; }
        public DbSet<Recibos> Recibos { get; set; }
        public DbSet<Ocupaciones> Ocupaciones { get; set; }
        public DbSet<Nacionalidades> Nacionalidades { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<Sectores> Sectores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}