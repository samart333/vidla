namespace Vidla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "Name", c => c.String());
            DropColumn("dbo.Genres", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Type", c => c.String());
            DropColumn("dbo.Genres", "Name");
        }
    }
}
