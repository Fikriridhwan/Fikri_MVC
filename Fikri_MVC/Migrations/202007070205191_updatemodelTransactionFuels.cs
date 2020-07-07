namespace Fikri_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodelTransactionFuels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_R_TransactionFuel", "Consumer_Id", c => c.Int());
            CreateIndex("dbo.TB_R_TransactionFuel", "Consumer_Id");
            AddForeignKey("dbo.TB_R_TransactionFuel", "Consumer_Id", "dbo.TB_M_Consumer", "Consumer_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_R_TransactionFuel", "Consumer_Id", "dbo.TB_M_Consumer");
            DropIndex("dbo.TB_R_TransactionFuel", new[] { "Consumer_Id" });
            DropColumn("dbo.TB_R_TransactionFuel", "Consumer_Id");
        }
    }
}
