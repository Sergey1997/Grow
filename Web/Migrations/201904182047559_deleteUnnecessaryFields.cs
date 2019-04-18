namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteUnnecessaryFields : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String());
        }
    }
}
