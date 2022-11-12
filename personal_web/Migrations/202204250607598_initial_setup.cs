namespace personal_web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_setup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Date = c.String(nullable: false, maxLength: 10),
                        ShortDescription = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BlogID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 20),
                        Email = c.String(maxLength: 30),
                        Phone = c.String(maxLength: 10),
                        Message = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.Homes",
                c => new
                    {
                        HomeID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 30),
                        TitleDescription = c.String(nullable: false, maxLength: 100),
                        Introduction = c.String(nullable: false, maxLength: 200),
                        Image = c.String(nullable: false),
                        CalltoAction = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.HomeID);
            
            CreateTable(
                "dbo.links",
                c => new
                    {
                        LinkID = c.Int(nullable: false, identity: true),
                        Facebook = c.String(maxLength: 100),
                        Instagram = c.String(maxLength: 100),
                        Twitter = c.String(maxLength: 100),
                        LinkedIn = c.String(maxLength: 100),
                        Github = c.String(maxLength: 100),
                        Ohters = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.LinkID);
            
            CreateTable(
                "dbo.skillAttributes",
                c => new
                    {
                        SkillAttributeID = c.Int(nullable: false, identity: true),
                        SkillTitle = c.String(nullable: false, maxLength: 50),
                        Remarks = c.String(maxLength: 50),
                        SkillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillAttributeID)
                .ForeignKey("dbo.Skills", t => t.SkillID, cascadeDelete: true)
                .Index(t => t.SkillID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SkillID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.skillAttributes", "SkillID", "dbo.Skills");
            DropIndex("dbo.skillAttributes", new[] { "SkillID" });
            DropTable("dbo.Skills");
            DropTable("dbo.skillAttributes");
            DropTable("dbo.links");
            DropTable("dbo.Homes");
            DropTable("dbo.Contacts");
            DropTable("dbo.Blogs");
            DropTable("dbo.Abouts");
        }
    }
}
