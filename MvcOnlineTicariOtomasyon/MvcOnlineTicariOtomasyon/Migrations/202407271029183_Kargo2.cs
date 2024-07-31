namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kargo2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KargoDetays", "Personel", c => c.String());
            DropColumn("dbo.KargoDetays", "Peronel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KargoDetays", "Peronel", c => c.String());
            DropColumn("dbo.KargoDetays", "Personel");
        }
    }
}
