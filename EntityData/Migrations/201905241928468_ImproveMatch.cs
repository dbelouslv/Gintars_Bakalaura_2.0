namespace EntityData.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ImproveMatch : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Match", new[] { "TeamOneId" });
            AlterColumn("dbo.Match", "TeamOneId", c => c.Int());
            AlterColumn("dbo.Match", "Date", c => c.DateTime());
            CreateIndex("dbo.Match", "TeamOneId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Match", new[] { "TeamOneId" });
            AlterColumn("dbo.Match", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Match", "TeamOneId", c => c.Int(nullable: false));
            CreateIndex("dbo.Match", "TeamOneId");
        }
    }
}
