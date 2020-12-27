namespace Fitness.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeFixes1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eatings", "Food_Id", c => c.Int());
            CreateIndex("dbo.Eatings", "Food_Id");
            AddForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods");
            DropIndex("dbo.Eatings", new[] { "Food_Id" });
            DropColumn("dbo.Eatings", "Food_Id");
        }
    }
}
