using System.Data.Entity;
using WebDemo.Models;

namespace WebDemo.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("name=WebDemo")
        {
        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
		
		、、建表时表名后不会加S
		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
          //  modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}