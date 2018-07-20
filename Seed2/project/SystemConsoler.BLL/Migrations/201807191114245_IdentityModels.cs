namespace SystemConsoler.BLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LoginId = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(),
                        GroupId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                        LastLogin = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        ApplicationUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
