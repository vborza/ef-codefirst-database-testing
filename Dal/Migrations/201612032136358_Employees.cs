namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCardNumber = c.String(maxLength: 30),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IdCardNumber, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "IdCardNumber" });
            DropTable("dbo.Employees");
        }
    }
}
