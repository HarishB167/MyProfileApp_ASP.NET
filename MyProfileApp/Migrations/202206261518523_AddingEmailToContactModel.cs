namespace MyProfileApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmailToContactModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Email");
        }
    }
}
