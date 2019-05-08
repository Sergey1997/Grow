namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModulePointsAddMaterials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModulePoints",
                c => new
                    {
                        ModulePointId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModulePointId)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialId)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Note = c.String(),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.SkillId);
            
            AddColumn("dbo.Skills", "Lections", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.Materials", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.ModulePoints", "SkillId", "dbo.Skills");
            DropIndex("dbo.Tasks", new[] { "SkillId" });
            DropIndex("dbo.Materials", new[] { "TaskId" });
            DropIndex("dbo.ModulePoints", new[] { "SkillId" });
            DropColumn("dbo.Skills", "Lections");
            DropTable("dbo.Tasks");
            DropTable("dbo.Materials");
            DropTable("dbo.ModulePoints");
        }
    }
}
