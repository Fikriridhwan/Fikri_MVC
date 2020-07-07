namespace Fikri_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelTransactionFuels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_R_TransactionFuel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FuelType = c.String(),
                        Capacity = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_M_Employee", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_R_TransactionFuel", "Employee_Id", "dbo.TB_M_Employee");
            DropIndex("dbo.TB_R_TransactionFuel", new[] { "Employee_Id" });
            DropTable("dbo.TB_R_TransactionFuel");
        }
    }
}
