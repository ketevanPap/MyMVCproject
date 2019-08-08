namespace MyMVCproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        IsSubscibedToNewletter = c.Boolean(nullable: false),
                        MemberShipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MemberShipTypeId, cascadeDelete: true)
                .Index(t => t.MemberShipTypeId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
        }
    }
}
