namespace GuitarAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrvaMigracija : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guitars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        NumberOfStrings = c.Int(nullable: false),
                        NumberOfFrets = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        ImageLink = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Guitars");
        }
    }
}
