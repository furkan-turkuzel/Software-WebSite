namespace AnalitikBilisimSite.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        SmallWriting = c.String(nullable: false, maxLength: 500),
                        BigWriting = c.String(),
                        Image = c.String(),
                        MissionTitle = c.String(),
                        MissionWriting = c.String(),
                        MissionImage = c.String(),
                        PlanTitle = c.String(),
                        PlanWriting = c.String(),
                        PlanImage = c.String(),
                        VisionTitle = c.String(),
                        VisionWriting = c.String(),
                        VisionImage = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Commons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageID = c.Int(nullable: false),
                        Logo = c.String(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 30),
                        URL = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Fax = c.String(nullable: false, maxLength: 40),
                        Address = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 40),
                        GoogleMap = c.String(),
                        Facebook = c.String(maxLength: 50),
                        Twitter = c.String(maxLength: 50),
                        Youtube = c.String(maxLength: 50),
                        Instagram = c.String(),
                        Google = c.String(maxLength: 50),
                        Linkedin = c.String(maxLength: 50),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        LanguageName = c.String(nullable: false),
                        Logo = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true, name: "Code_Unique");
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        SmallWriting = c.String(nullable: false, maxLength: 500),
                        BigWriting = c.String(nullable: false),
                        UserID = c.Int(nullable: false),
                        Image = c.String(),
                        NewsDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 40),
                        Email = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 15),
                        UserRole = c.String(nullable: false),
                        UserImage = c.String(),
                        Facebook = c.String(maxLength: 50),
                        Twitter = c.String(maxLength: 50),
                        Youtube = c.String(maxLength: 50),
                        Linkedin = c.String(maxLength: 50),
                        Instagram = c.String(maxLength: 50),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.UserName, unique: true, name: "UserName_Unique");
            
            CreateTable(
                "dbo.Referances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageID = c.Int(nullable: false),
                        ReferanceType = c.String(),
                        ReferanceName = c.String(nullable: false, maxLength: 100),
                        ReferancePhone = c.String(nullable: false, maxLength: 11),
                        ReferanceAddress = c.String(nullable: false, maxLength: 200),
                        ReferanceLogo = c.String(nullable: false),
                        Description = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        SmallWriting = c.String(nullable: false, maxLength: 500),
                        BigWriting = c.String(nullable: false),
                        Image = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ServicesDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ServiceID = c.Int(nullable: false),
                        LanguageID = c.Int(nullable: false),
                        ServiceDetailTitle = c.String(),
                        ServiceDetailWriting = c.String(),
                        ServiceDetailImage = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Services", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.ServiceID);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageID = c.Int(nullable: false),
                        SliderURL = c.String(),
                        sliderTitle = c.String(),
                        SliderWriting = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Solutions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        LanguageID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        SmallWriting = c.String(nullable: false, maxLength: 500),
                        BigWriting = c.String(nullable: false),
                        Image = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SolutionCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.SolutionCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageID = c.Int(nullable: false),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        Message = c.String(),
                        SendTime = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        Readed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Solutions", "CategoryID", "dbo.SolutionCategories");
            DropForeignKey("dbo.ServicesDetails", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.News", "UserID", "dbo.Users");
            DropIndex("dbo.Solutions", new[] { "CategoryID" });
            DropIndex("dbo.ServicesDetails", new[] { "ServiceID" });
            DropIndex("dbo.Users", "UserName_Unique");
            DropIndex("dbo.News", new[] { "UserID" });
            DropIndex("dbo.Languages", "Code_Unique");
            DropTable("dbo.Visitors");
            DropTable("dbo.SolutionCategories");
            DropTable("dbo.Solutions");
            DropTable("dbo.Sliders");
            DropTable("dbo.ServicesDetails");
            DropTable("dbo.Services");
            DropTable("dbo.Referances");
            DropTable("dbo.Users");
            DropTable("dbo.News");
            DropTable("dbo.Languages");
            DropTable("dbo.Contacts");
            DropTable("dbo.Commons");
            DropTable("dbo.Abouts");
        }
    }
}
