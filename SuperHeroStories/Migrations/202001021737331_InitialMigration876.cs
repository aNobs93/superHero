namespace SuperHeroStories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration876 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuperHeroes", "AlterEgo", c => c.String());
            DropColumn("dbo.SuperHeroes", "alterEgoName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SuperHeroes", "alterEgoName", c => c.String());
            DropColumn("dbo.SuperHeroes", "AlterEgo");
        }
    }
}
