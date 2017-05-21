namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nvarchar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PassportItems", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.PassportItems", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.PassportItems", "Series", c => c.String(nullable: false));
            AlterColumn("dbo.PassportItems", "Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PassportItems", "Number", c => c.String());
            AlterColumn("dbo.PassportItems", "Series", c => c.String());
            AlterColumn("dbo.PassportItems", "Name", c => c.String());
            AlterColumn("dbo.PassportItems", "Surname", c => c.String());
        }
    }
}
