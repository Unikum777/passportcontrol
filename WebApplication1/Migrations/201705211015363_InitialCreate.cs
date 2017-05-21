namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PassportItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        MiddleName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                        Series = c.String(),
                        Number = c.String(),
                        DateOfIssue = c.DateTime(nullable: false),
                        IssuaDepartmentCode = c.String(),
                        PlaceOfBirthId = c.Int(nullable: false),
                        PlaceOfIssue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlaceOfBirths", t => t.PlaceOfBirthId, cascadeDelete: true)
                .Index(t => t.PlaceOfBirthId);
            
            CreateTable(
                "dbo.PlaceOfBirths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PassportItems", "PlaceOfBirthId", "dbo.PlaceOfBirths");
            DropIndex("dbo.PassportItems", new[] { "PlaceOfBirthId" });
            DropTable("dbo.PlaceOfBirths");
            DropTable("dbo.PassportItems");
        }
    }
}
