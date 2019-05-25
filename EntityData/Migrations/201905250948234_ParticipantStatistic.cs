namespace EntityData.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ParticipantStatistic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Particapant", "Points", c => c.Int(nullable: false));
            AddColumn("dbo.Particapant", "REB", c => c.Int(nullable: false));
            AddColumn("dbo.Particapant", "Missed", c => c.Int(nullable: false));
            AddColumn("dbo.Particapant", "Fouls", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Particapant", "Fouls");
            DropColumn("dbo.Particapant", "Missed");
            DropColumn("dbo.Particapant", "REB");
            DropColumn("dbo.Particapant", "Points");
        }
    }
}
