namespace Vidla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameOfMovieRentedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "NameofMovieRented", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "NameofMovieRented");
        }
    }
}
