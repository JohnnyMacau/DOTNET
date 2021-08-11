namespace MvcDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ClassID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        Address = c.String(),
                        Class_ClassID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Class", t => t.Class_ClassID)
                .Index(t => t.Class_ClassID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "Class_ClassID", "dbo.Class");
            DropIndex("dbo.Student", new[] { "Class_ClassID" });
            DropTable("dbo.Student");
            DropTable("dbo.Class");
        }
    }
}
