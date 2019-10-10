namespace Vidla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingCustomerModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MemershipType_Id", "dbo.MemershipTypes");
            DropIndex("dbo.Customers", new[] { "MemershipType_Id" });
            DropTable("dbo.Customers");
            DropTable("dbo.MemershipTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MemershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsSubscribedToNewsLetter = c.Boolean(nullable: false),
                        MembershipTypeId = c.Byte(nullable: false),
                        MemershipType_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Customers", "MemershipType_Id");
            AddForeignKey("dbo.Customers", "MemershipType_Id", "dbo.MemershipTypes", "Id");
        }
    }
}
