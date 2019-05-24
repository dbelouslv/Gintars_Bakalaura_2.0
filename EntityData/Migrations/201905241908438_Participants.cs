namespace EntityData.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Participants : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Particapant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatchId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Number = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Match", t => t.MatchId)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .Index(t => t.MatchId)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Particapant", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Particapant", "MatchId", "dbo.Match");
            DropIndex("dbo.Particapant", new[] { "TeamId" });
            DropIndex("dbo.Particapant", new[] { "MatchId" });
            DropTable("dbo.Particapant");
        }
    }
}
