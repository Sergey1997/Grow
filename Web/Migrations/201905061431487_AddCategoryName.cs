namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryOfSkills", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CategoryOfSkills", "Name");
        }
    }
}
