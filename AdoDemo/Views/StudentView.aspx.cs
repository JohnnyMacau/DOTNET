using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdoDemo.Models;
using DAL;

namespace AdoDemo.Views
{
    //use gridview
    public partial class StudentView : System.Web.UI.Page
    {
        StudentDal studentDal = new StudentDal();
        DataTable classTable = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Page_Load");
            if (!Page.IsPostBack)
            {
                Bind();
             }
            ClassDal dal = new ClassDal();
            classTable = dal.GetList(0);

        }

        private void Bind()
        {
            string classsid = Request.QueryString["classID"];
            DataTable dt = null;
            if (classsid != null && classsid != "")
            {
                dt = studentDal.GetList(Convert.ToInt32(classsid));
            }
            else
            {

                dt = studentDal.GetList();
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                int studentid = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("Label1") as Label).Text);

                StudentDal dal = new StudentDal();
                dal.Del(studentid);

                Response.Write("<script>alert('删除成功！')</script>");
                GridView1.EditIndex = -1;
                Bind();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('删除失败！')</script>");
                //throw;
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
                    DropDownList1.DataSource = classTable;
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
            try
            {
                int studentid = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("Label1") as Label).Text);
                string studentname = (GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox).Text;
                int classid = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList).SelectedValue);

                Models.Students student = new Models.Students();
                student.StudentID = studentid;
                student.StudentName = studentname;
                student.ClassID = classid;
                student.Address = "";
                studentDal.Update(student);

                GridView1.EditIndex = -1;
                Bind();
                Response.Write("<script>alert('修改成功！')</script>");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                
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