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

namespace WebDemo.Views
{
    //use gridview
    public partial class Students : System.Web.UI.Page
    {
        List<Class> classList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Page_Load");
            if (!Page.IsPostBack)
            {
                Bind();
             }

            var _db = new WebDemo.Models.StudentContext();
            IQueryable<Class> query = _db.Classes;
            classList = query.ToList<Class>();
        }

        private void Bind()
        {
            var _db = new WebDemo.Models.StudentContext();
            string classsid = Request.QueryString["classID"];

            List<StudentInfo> data = null;

            String sql = "select s.studentid, s.studentname, c.classid, c.classname from students s, classes c where s.classid = c.classid";
           
            if(classsid!=null && classsid != "")
            {
               sql = sql + " and s.classid = @classsid";
               SqlParameter[] para =  {
                   new  SqlParameter("@classsid",classsid),
               };
                data = _db.Database.SqlQuery<StudentInfo>(sql, para).ToList();
            }
            else
            {
                data = _db.Database.SqlQuery<StudentInfo>(sql).ToList();
            }


            //int classID = Convert.ToInt32(Request.QueryString["classID"]);
            //int classID = 1;
            //var data = from student in _db.Students
            //        where student.ClassID == classID
            //        orderby student.StudentID ascending
            //        select new { studentid =student.StudentID, studentname=student.StudentName };

            GridView1.DataSource = data;
            GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        
            int studentid = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("Label1") as Label).Text);

            var _db = new WebDemo.Models.StudentContext();

            IQueryable<Student> query = from s in _db.Students
                                        where s.StudentID == studentid
                                        select s;
            Student student = query.FirstOrDefault();
            _db.Students.Remove(student);
            int result = _db.SaveChanges();

            if (result == 1)
            {
                Response.Write("<script>alert('删除成功！')</script>");
                GridView1.EditIndex = -1;
                Bind();
            }
            else
            {
                Response.Write("<script>alert('删除失败！')</script>");
            }
        }
        //让当前行处于修改状态
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("GridView1_RowEditing");


            GridView1.EditIndex = e.NewEditIndex;
            DropDownList DropDownList1 = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList1");

            Bind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("GridView1_RowUpdated");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList DropDownList1 = ((DropDownList)e.Row.FindControl("DropDownList1"));
                if (DropDownList1 != null)
                {
                    DropDownList1.Items.Clear();
                    DropDownList1.DataSource = classList;
                    DropDownList1.DataTextField = "ClassName";
                    DropDownList1.DataValueField = "ClassID";
                    DropDownList1.DataBind();
                    DropDownList1.SelectedValue = ((Label)e.Row.FindControl("Label7")).Text;
                }
            }
        }
        
        //取消编辑
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Bind();
        }
        //更新至数据库
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int studentid = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("Label1") as Label).Text);
            string studentname = (GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox).Text;
            int classid = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList).SelectedValue);

            var _db = new WebDemo.Models.StudentContext();


            //int classID = Convert.ToInt32(Request.QueryString["classID"]);
            //int classID = 1;
            IQueryable<Student> query = from s in _db.Students
                       where s.StudentID == studentid
                       select s;
            Student student = query.FirstOrDefault();
            student.StudentID = studentid;
            student.StudentName = studentname;
            student.ClassID = classid;

            //不需要？
            //_db.Entry<Student>(student).State = System.Data.Entity.EntityState.Modified;

            try
            {
               _db.SaveChanges();

                Response.Write("<script>alert('修改成功！')</script>");
                GridView1.EditIndex = -1;
                Bind();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('修改失败！')</script>");
                //throw;
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AddNewStudent");
        }
    }
}