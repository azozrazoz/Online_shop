namespace Online_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goods", "PathToPicture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Goods", "PathToPicture");
        }
    }
}
