namespace MedicineTestTask.Orm
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        SecondName = c.String(nullable: false, maxLength: 150),
                        BirthDate = c.DateTime(nullable: false),
                        Guid = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Guid, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Patients", new[] { "Guid" });
            DropTable("dbo.Patients");
        }
    }
}
