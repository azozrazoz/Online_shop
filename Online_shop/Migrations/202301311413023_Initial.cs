namespace Online_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(),
                        PasswordConfirm = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoodsCategory",
                c => new
                    {
                        GoodsId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GoodsId, t.CategoryId })
                .ForeignKey("dbo.Goods", t => t.GoodsId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.GoodsId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoodsCategory", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.GoodsCategory", "GoodsId", "dbo.Goods");
            DropIndex("dbo.GoodsCategory", new[] { "CategoryId" });
            DropIndex("dbo.GoodsCategory", new[] { "GoodsId" });
            DropTable("dbo.GoodsCategory");
            DropTable("dbo.Users");
            DropTable("dbo.Goods");
            DropTable("dbo.Categories");
        }
    }
}
