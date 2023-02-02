namespace Online_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "PathToPicture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "PathToPicture");
        }
    }
}
