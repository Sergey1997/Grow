namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "Picture", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "Picture");
        }
    }
}
