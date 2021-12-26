namespace MarketingSolution.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_IsProcessed_Column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receivers", "IsProcessed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receivers", "IsProcessed");
        }
    }
}
