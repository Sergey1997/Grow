namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeUserId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Goals", new[] { "User_Id" });
            DropColumn("dbo.Goals", "UserId");
            RenameColumn(table: "dbo.Goals", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Goals", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Goals", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Goals", new[] { "UserId" });
            AlterColumn("dbo.Goals", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Goals", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Goals", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Goals", "User_Id");
        }
    }
}
