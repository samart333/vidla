namespace Vidla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeNumberAvailableEqualToNumberInStock : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET NumberAvailable = NumberInSTock");
        }
        
        public override void Down()
        {
        }
    }
}
