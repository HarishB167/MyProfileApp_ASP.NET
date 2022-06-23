namespace MyProfileApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExperienceModelDurationChangedToDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Experiences", "Start", c => c.DateTime(nullable: false));
            AddColumn("dbo.Experiences", "End", c => c.DateTime(nullable: false));
            DropColumn("dbo.Experiences", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Experiences", "Duration", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.Experiences", "End");
            DropColumn("dbo.Experiences", "Start");
        }
    }
}
