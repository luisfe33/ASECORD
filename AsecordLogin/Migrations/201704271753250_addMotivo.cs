namespace AsecordLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMotivo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Citas_locales", "Motivo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Citas_locales", "Motivo");
        }
    }
}
