namespace WebPatter.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String());
            AddColumn("dbo.AspNetUsers", "Height", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Waist", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "HipWidth", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "AccountId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "RegistrationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "ActivationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ActivationDate");
            DropColumn("dbo.AspNetUsers", "RegistrationDate");
            DropColumn("dbo.AspNetUsers", "AccountId");
            DropColumn("dbo.AspNetUsers", "HipWidth");
            DropColumn("dbo.AspNetUsers", "Waist");
            DropColumn("dbo.AspNetUsers", "Height");
            DropColumn("dbo.AspNetUsers", "Phone");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
