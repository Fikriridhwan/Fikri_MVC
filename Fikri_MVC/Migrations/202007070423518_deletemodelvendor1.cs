namespace Fikri_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletemodelvendor1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_R_Transaction", "TransactionFuel_Id", "dbo.TB_R_TransactionFuel");
            DropIndex("dbo.TB_R_Transaction", new[] { "TransactionFuel_Id" });
            DropTable("dbo.TB_R_Transaction");
            DropTable("dbo.TB_M_Vendor");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TB_M_Vendor",
                c => new
                    {
                        Vendor_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Vendor_Id);
            
            CreateTable(
                "dbo.TB_R_Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        TransactionFuel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TB_R_Transaction", "TransactionFuel_Id");
            AddForeignKey("dbo.TB_R_Transaction", "TransactionFuel_Id", "dbo.TB_R_TransactionFuel", "Id");
        }
    }
}
