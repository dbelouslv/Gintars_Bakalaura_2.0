namespace EntityData.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AssistForPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Particapant", "Assisted", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Particapant", "Assisted");
        }
    }
}
