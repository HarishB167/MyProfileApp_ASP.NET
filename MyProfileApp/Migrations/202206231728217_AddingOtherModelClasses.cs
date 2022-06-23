namespace MyProfileApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOtherModelClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        ProfileLink = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qualification = c.String(nullable: false),
                        Institute = c.String(nullable: false),
                        Score = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Subtitle = c.String(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Responsibilities = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Subtitle = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Subtitle = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainings", "PersonId", "dbo.People");
            DropForeignKey("dbo.Skills", "PersonId", "dbo.People");
            DropForeignKey("dbo.Projects", "PersonId", "dbo.People");
            DropForeignKey("dbo.Languages", "PersonId", "dbo.People");
            DropForeignKey("dbo.Experiences", "PersonId", "dbo.People");
            DropForeignKey("dbo.Educations", "PersonId", "dbo.People");
            DropForeignKey("dbo.Contacts", "PersonId", "dbo.People");
            DropIndex("dbo.Trainings", new[] { "PersonId" });
            DropIndex("dbo.Skills", new[] { "PersonId" });
            DropIndex("dbo.Projects", new[] { "PersonId" });
            DropIndex("dbo.Languages", new[] { "PersonId" });
            DropIndex("dbo.Experiences", new[] { "PersonId" });
            DropIndex("dbo.Educations", new[] { "PersonId" });
            DropIndex("dbo.Contacts", new[] { "PersonId" });
            DropTable("dbo.Trainings");
            DropTable("dbo.Skills");
            DropTable("dbo.Projects");
            DropTable("dbo.Languages");
            DropTable("dbo.Experiences");
            DropTable("dbo.Educations");
            DropTable("dbo.Contacts");
        }
    }
}
