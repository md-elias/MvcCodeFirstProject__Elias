namespace MvcCodeFirstProject__Elias.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        BookName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        BorrowDate = c.DateTime(nullable: false),
                        ImagePath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
