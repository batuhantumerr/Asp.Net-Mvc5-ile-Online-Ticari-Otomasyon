namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kargo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoDetays",
                c => new
                    {
                        KargoDetayId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(),
                        TakipKodu = c.String(),
                        Peronel = c.String(),
                        Alıcı = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoDetayId);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        KargoTakipId = c.Int(nullable: false, identity: true),
                        TakipKodu = c.String(),
                        Aciklama = c.String(),
                        TarihZaman = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoTakipId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoTakips");
            DropTable("dbo.KargoDetays");
        }
    }
}
