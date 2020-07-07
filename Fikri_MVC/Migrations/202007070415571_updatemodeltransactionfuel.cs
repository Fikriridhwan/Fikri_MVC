namespace Fikri_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodeltransactionfuel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_R_TransactionFuel", "OrderDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.TB_R_TransactionFuel", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_R_TransactionFuel", "Name", c => c.String());
            DropColumn("dbo.TB_R_TransactionFuel", "OrderDate");
        }
    }
}
