
namespace UpdateEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        JanrId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Janrs", t => t.JanrId, cascadeDelete: true)
                .Index(t => t.JanrId);
            
            CreateTable(
                "dbo.Janrs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "JanrId", "dbo.Janrs");
            DropIndex("dbo.Books", new[] { "JanrId" });
            DropTable("dbo.Janrs");
            DropTable("dbo.Books");
        }
    }
}
