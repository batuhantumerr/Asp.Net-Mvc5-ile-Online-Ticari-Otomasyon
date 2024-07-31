namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kargo3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KargoDetays", "Alici", c => c.String());
            DropColumn("dbo.KargoDetays", "Alıcı");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KargoDetays", "Alıcı", c => c.String());
            DropColumn("dbo.KargoDetays", "Alici");
        }
    }
}
