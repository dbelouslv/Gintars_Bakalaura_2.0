namespace EntityData.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ImproveMatch : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Match", new[] { "TeamOneId" });
            DropIndex("dbo.Match", new[] { "TeamTwoId" });
            AlterColumn("dbo.Match", "TeamOneId", c => c.Int());
            AlterColumn("dbo.Match", "TeamTwoId", c => c.Int());
            AlterColumn("dbo.Match", "Date", c => c.DateTime());
            CreateIndex("dbo.Match", "TeamOneId");
            CreateIndex("dbo.Match", "TeamTwoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Match", new[] { "TeamTwoId" });
            DropIndex("dbo.Match", new[] { "TeamOneId" });
            AlterColumn("dbo.Match", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Match", "TeamTwoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Match", "TeamOneId", c => c.Int(nullable: false));
            CreateIndex("dbo.Match", "TeamTwoId");
            CreateIndex("dbo.Match", "TeamOneId");
        }
    }
}
