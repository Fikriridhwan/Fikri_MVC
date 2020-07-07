namespace Fikri_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelconsumer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_M_Consumer",
                c => new
                    {
                        Consumer_Id = c.Int(nullable: false, identity: true),
                        Vehicle_Name = c.String(),
                        Fuel_Type = c.String(),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Consumer_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TB_M_Consumer");
        }
    }
}
