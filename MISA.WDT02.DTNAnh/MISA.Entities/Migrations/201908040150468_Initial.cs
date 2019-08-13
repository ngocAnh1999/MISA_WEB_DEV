namespace MISA.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Guid(nullable: false, defaultValueSql: "newid()", identity: true),
                        CustomerNo = c.String(nullable: false),
                        CustomerName = c.String(nullable: false),
                        CustomerPhone = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        CustomerGroup = c.String(),
                        Note = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
