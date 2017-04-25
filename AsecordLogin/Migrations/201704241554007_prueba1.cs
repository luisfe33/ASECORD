namespace AsecordLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citas_consulares",
                c => new
                    {
                        CitaID = c.Int(nullable: false, identity: true),
                        Fecha = c.String(),
                        Hora = c.String(),
                        Lugar = c.String(),
                        Tipo_visa = c.String(),
                        UID = c.String(),
                        Formulario = c.String(),
                        Comentario = c.String(),
                        Estatus = c.Int(nullable: false),
                        Cliente_CLienteID = c.Int(),
                    })
                .PrimaryKey(t => t.CitaID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_CLienteID)
                .Index(t => t.Cliente_CLienteID);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        CLienteID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Fecha_nacimiento = c.String(),
                        Cedula = c.String(),
                        Sexo = c.String(),
                        Estado_civil = c.String(),
                        Direccion = c.String(),
                        Email = c.String(),
                        Fecha_ingreso = c.String(),
                        Pasaporte = c.String(),
                        Comentario = c.String(),
                        Tel_1 = c.String(),
                        Tel_2 = c.String(),
                        Tel_3 = c.String(),
                        Ocupacion = c.String(),
                        Empresa_Nombre = c.String(),
                        Empresa_Dir = c.String(),
                        Empresa_Tel = c.String(),
                        Empresa_Labor = c.String(),
                        TipoDePago = c.String(),
                        Estatus_1 = c.String(),
                        Estatus_2 = c.String(),
                        Estatus_3 = c.String(),
                        Estatus_4 = c.String(),
                        Estatus_5 = c.String(),
                        Estatus_6 = c.String(),
                        Estatus_7 = c.String(),
                        Estatus_8 = c.String(),
                        Estatus_9 = c.String(),
                        Estatus_10 = c.String(),
                        P1 = c.String(),
                        P2 = c.String(),
                        P3 = c.String(),
                        P4 = c.String(),
                        P5 = c.String(),
                        P6 = c.String(),
                        P7 = c.String(),
                        P8 = c.String(),
                        P9 = c.String(),
                        P10 = c.String(),
                        Provincia_ProvinciaID = c.Int(),
                        Ciudad_CiudadID = c.Int(),
                        Nacionalidad_NacionalidadID = c.Int(),
                        Sector_SectorID = c.Int(),
                        Ocupaciones_OcupacionID = c.Int(),
                    })
                .PrimaryKey(t => t.CLienteID)
                .ForeignKey("dbo.Provincias", t => t.Provincia_ProvinciaID)
                .ForeignKey("dbo.Ciudades", t => t.Ciudad_CiudadID)
                .ForeignKey("dbo.Nacionalidades", t => t.Nacionalidad_NacionalidadID)
                .ForeignKey("dbo.Sectores", t => t.Sector_SectorID)
                .ForeignKey("dbo.Ocupaciones", t => t.Ocupaciones_OcupacionID)
                .Index(t => t.Provincia_ProvinciaID)
                .Index(t => t.Ciudad_CiudadID)
                .Index(t => t.Nacionalidad_NacionalidadID)
                .Index(t => t.Sector_SectorID)
                .Index(t => t.Ocupaciones_OcupacionID);
            
            CreateTable(
                "dbo.Ciudades",
                c => new
                    {
                        CiudadID = c.Int(nullable: false, identity: true),
                        Nombre_ciudad = c.String(),
                        Provincia_ProvinciaID = c.Int(),
                    })
                .PrimaryKey(t => t.CiudadID)
                .ForeignKey("dbo.Provincias", t => t.Provincia_ProvinciaID)
                .Index(t => t.Provincia_ProvinciaID);
            
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        ProvinciaID = c.Int(nullable: false, identity: true),
                        Nombre_provincia = c.String(),
                    })
                .PrimaryKey(t => t.ProvinciaID);
            
            CreateTable(
                "dbo.Sectores",
                c => new
                    {
                        SectorID = c.Int(nullable: false, identity: true),
                        Nombre_sector = c.String(),
                        Ciudad_CiudadID = c.Int(),
                    })
                .PrimaryKey(t => t.SectorID)
                .ForeignKey("dbo.Ciudades", t => t.Ciudad_CiudadID)
                .Index(t => t.Ciudad_CiudadID);
            
            CreateTable(
                "dbo.Nacionalidades",
                c => new
                    {
                        NacionalidadID = c.Int(nullable: false, identity: true),
                        Nombre_nacionalidad = c.String(),
                    })
                .PrimaryKey(t => t.NacionalidadID);
            
            CreateTable(
                "dbo.Recibos",
                c => new
                    {
                        ReciboID = c.Int(nullable: false, identity: true),
                        Fecha = c.String(),
                        Concepto = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Forma_pago = c.Int(nullable: false),
                        Comentario = c.String(),
                        Estatus = c.Int(nullable: false),
                        Cliente_CLienteID = c.Int(),
                    })
                .PrimaryKey(t => t.ReciboID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_CLienteID)
                .Index(t => t.Cliente_CLienteID);
            
            CreateTable(
                "dbo.Citas_locales",
                c => new
                    {
                        CitaID = c.Int(nullable: false, identity: true),
                        Fecha = c.String(),
                        Hora = c.String(),
                        Tipo = c.String(),
                        Comentario = c.String(),
                        Estatus = c.Int(nullable: false),
                        Cliente_CLienteID = c.Int(),
                    })
                .PrimaryKey(t => t.CitaID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_CLienteID)
                .Index(t => t.Cliente_CLienteID);
            
            CreateTable(
                "dbo.Ocupaciones",
                c => new
                    {
                        OcupacionID = c.Int(nullable: false, identity: true),
                        Nombre_ocupacion = c.String(),
                    })
                .PrimaryKey(t => t.OcupacionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "Ocupaciones_OcupacionID", "dbo.Ocupaciones");
            DropForeignKey("dbo.Citas_locales", "Cliente_CLienteID", "dbo.Clientes");
            DropForeignKey("dbo.Citas_consulares", "Cliente_CLienteID", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "Sector_SectorID", "dbo.Sectores");
            DropForeignKey("dbo.Recibos", "Cliente_CLienteID", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "Nacionalidad_NacionalidadID", "dbo.Nacionalidades");
            DropForeignKey("dbo.Clientes", "Ciudad_CiudadID", "dbo.Ciudades");
            DropForeignKey("dbo.Sectores", "Ciudad_CiudadID", "dbo.Ciudades");
            DropForeignKey("dbo.Clientes", "Provincia_ProvinciaID", "dbo.Provincias");
            DropForeignKey("dbo.Ciudades", "Provincia_ProvinciaID", "dbo.Provincias");
            DropIndex("dbo.Citas_locales", new[] { "Cliente_CLienteID" });
            DropIndex("dbo.Recibos", new[] { "Cliente_CLienteID" });
            DropIndex("dbo.Sectores", new[] { "Ciudad_CiudadID" });
            DropIndex("dbo.Ciudades", new[] { "Provincia_ProvinciaID" });
            DropIndex("dbo.Clientes", new[] { "Ocupaciones_OcupacionID" });
            DropIndex("dbo.Clientes", new[] { "Sector_SectorID" });
            DropIndex("dbo.Clientes", new[] { "Nacionalidad_NacionalidadID" });
            DropIndex("dbo.Clientes", new[] { "Ciudad_CiudadID" });
            DropIndex("dbo.Clientes", new[] { "Provincia_ProvinciaID" });
            DropIndex("dbo.Citas_consulares", new[] { "Cliente_CLienteID" });
            DropTable("dbo.Ocupaciones");
            DropTable("dbo.Citas_locales");
            DropTable("dbo.Recibos");
            DropTable("dbo.Nacionalidades");
            DropTable("dbo.Sectores");
            DropTable("dbo.Provincias");
            DropTable("dbo.Ciudades");
            DropTable("dbo.Clientes");
            DropTable("dbo.Citas_consulares");
        }
    }
}
