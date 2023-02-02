namespace Online_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.GoodsOrder",
                c => new
                    {
                        GoodsId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GoodsId, t.OrderId })
                .ForeignKey("dbo.Goods", t => t.GoodsId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.GoodsId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoodsOrder", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.GoodsOrder", "GoodsId", "dbo.Goods");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropIndex("dbo.GoodsOrder", new[] { "OrderId" });
            DropIndex("dbo.GoodsOrder", new[] { "GoodsId" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropTable("dbo.GoodsOrder");
            DropTable("dbo.Orders");
        }
    }
}
