namespace MarketingSolution.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_by_column_modified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Receivers", "UpdatedOn", c => c.DateTime());
            AlterColumn("dbo.Users", "UpdatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Receivers", "UpdatedOn", c => c.DateTime(nullable: false));
        }
    }
}
