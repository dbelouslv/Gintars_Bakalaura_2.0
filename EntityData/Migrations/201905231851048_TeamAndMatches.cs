namespace EntityData.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class TeamAndMatches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Place = c.String(),
                        ReffereOne = c.String(),
                        ReffereTwo = c.String(),
                        TeamOneId = c.Int(nullable: false),
                        TeamTwoId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Team", t => t.TeamOneId)
                .ForeignKey("dbo.Team", t => t.TeamTwoId)
                .Index(t => t.TeamOneId)
                .Index(t => t.TeamTwoId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Match", "TeamTwoId", "dbo.Team");
            DropForeignKey("dbo.Match", "TeamOneId", "dbo.Team");
            DropIndex("dbo.Match", new[] { "TeamTwoId" });
            DropIndex("dbo.Match", new[] { "TeamOneId" });
            DropTable("dbo.Team");
            DropTable("dbo.Match");
        }
    }
}
