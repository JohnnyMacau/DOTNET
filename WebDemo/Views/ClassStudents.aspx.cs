using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDemo.Models;
//using Microsoft.EntityFrameworkCore.Relational;

namespace WebDemo.Views
{
    public partial class ClassStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Page_Load");
            //// Specify the data source.
            //int[] scores = new int[] { 97, 92, 81, 60 };

            //// Define the query expression.
            //IEnumerable<int> scoreQuery =
            //    from score in scores
            //    where score > 80
            //    select score;

            //// Execute the query.
            //foreach (int i in scoreQuery)
            //{
            //    System.Diagnostics.Debug.WriteLine(i + " ");
            //}

            GetClassStudents1();

        }
        public IQueryable<Student> GetClassStudents([QueryString("classID")] int? classID)
        {
            var _db = new WebDemo.Models.StudentContext();

            IQueryable<Student> query = _db.Students; ;
            if (classID.HasValue && classID > 0)
            {
                query = query.Where(p => p.ClassID == classID);

                //query = from student in _db.Students
                //        where student.ClassID == classID
                //        orderby student.StudentID ascending
                //        select student;

                //var s = from student in _db.Students
                //        where student.ClassID == classID
                //        group student by student.ClassID;

            }
            System.Diagnostics.Debug.WriteLine(query.ToList().Count());
            return query;
        }
        
        //user native query
        public DbRawSqlQuery<Student> GetClassStudents1()
        {
            var _db = new WebDemo.Models.StudentContext();

            //string strUpdateSQL = @"UPDATE test SET password=@pwd1 WHERE id=@id1;
            //                        UPDATE test SET password=@pwd2 WHERE id=@id2;";
            //SqlParameter[] para =  {
            //       new  SqlParameter("@pwd1","ceshi12we"),
            //       new  SqlParameter("@id1",1),
            //       new  SqlParameter("@pwd2","ceshi127890"),
            //       new  SqlParameter("@id2",2),
            //    };

            //int result = _db.Database.ExecuteSqlCommand(strUpdateSQL, para);
            //if (result > 0)
            //{
            //    Console.WriteLine("更新成功");
            //}

            //string strSQL = "SELECT * FROM students WHERE student_id='1'";
            //Student student = _db.Students.SqlQuery(strSQL).FirstOrDefault();
            //student.StudentName = "Johnny";
            //// 调用SaveChanges()方法可以更新StudentName字段
            //_db.SaveChanges();

            String sql = "select * from students";
            //String sql = "select studentname,address,classid from students s";


            DbRawSqlQuery<Student> list = _db.Database.SqlQuery<Student>(sql);
            //DbRawSqlQuery<String[]> list = _db.Database.SqlQuery<String[]>(sql);
            //int count = _db.Database.ExecuteSqlCommand(sql); //return 行数

            foreach (var item in list)
            {
                System.Diagnostics.Debug.WriteLine("ID:" + item.StudentID + " " + "名:" + item.StudentName);
            }

            return list;
        }
    }
}