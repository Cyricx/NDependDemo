namespace NDependTestWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialload : DbMigration
    {
        public override void Up()
        {

            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoes", "ToDoCategoryID", "dbo.ToDoCategories");
            DropIndex("dbo.ToDoes", new[] { "ToDoCategoryID" });
            DropTable("dbo.ToDoes");
            DropTable("dbo.ToDoCategories");
        }
    }
}
