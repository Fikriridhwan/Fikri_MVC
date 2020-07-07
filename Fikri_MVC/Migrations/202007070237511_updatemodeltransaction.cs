namespace Fikri_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodeltransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_R_Transaction", "TransactionFuel_Id", c => c.Int());
            CreateIndex("dbo.TB_R_Transaction", "TransactionFuel_Id");
            AddForeignKey("dbo.TB_R_Transaction", "TransactionFuel_Id", "dbo.TB_R_TransactionFuel", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_R_Transaction", "TransactionFuel_Id", "dbo.TB_R_TransactionFuel");
            DropIndex("dbo.TB_R_Transaction", new[] { "TransactionFuel_Id" });
            DropColumn("dbo.TB_R_Transaction", "TransactionFuel_Id");
        }
    }
}
