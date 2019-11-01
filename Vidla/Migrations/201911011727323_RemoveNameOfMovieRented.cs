namespace Vidla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNameOfMovieRented : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "NameofMovieRented");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "NameofMovieRented", c => c.String());
        }
    }
}
