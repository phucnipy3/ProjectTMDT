namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Verification", c => c.String());
            AddColumn("dbo.Users", "ExprireTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ExprireTime");
            DropColumn("dbo.Users", "Verification");
        }
    }
}
