namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusinessTrips : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessTrips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Kms = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeBusinessTrips",
                c => new
                    {
                        Employee_Id = c.Int(nullable: false),
                        BusinessTrip_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_Id, t.BusinessTrip_Id })
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("dbo.BusinessTrips", t => t.BusinessTrip_Id, cascadeDelete: true)
                .Index(t => t.Employee_Id)
                .Index(t => t.BusinessTrip_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeBusinessTrips", "BusinessTrip_Id", "dbo.BusinessTrips");
            DropForeignKey("dbo.EmployeeBusinessTrips", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.EmployeeBusinessTrips", new[] { "BusinessTrip_Id" });
            DropIndex("dbo.EmployeeBusinessTrips", new[] { "Employee_Id" });
            DropTable("dbo.EmployeeBusinessTrips");
            DropTable("dbo.BusinessTrips");
        }
    }
}
