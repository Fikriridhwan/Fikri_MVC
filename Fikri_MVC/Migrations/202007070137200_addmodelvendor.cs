namespace Fikri_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelvendor : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TB_M_Vendor");
        }
    }
}
