using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdoDemo.Models;
using DAL;

namespace AdoDemo.Views
{
    public partial class AddNewStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Page_Load");

            if (!Page.IsPostBack)
            {
                ClassDal dal = new ClassDal();
                DataTable classTable = dal.GetList(0);

                DropDownList1.Items.Clear();
                DropDownList1.DataSource = classTable;
                DropDownList1.DataTextField = "ClassName";
                DropDownList1.DataValueField = "ClassID";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("选择", "0"));
            }
        }

            protected void Button1_Click(object sender, EventArgs e)
        {
            StudentDal dal = new StudentDal();
            int id = dal.GetMaxId();

            Students student = new Students();
            student.StudentID = id;
            student.StudentName = TextBox1.Text;
            student.Address = TextBox2.Text;
            student.ClassID = Convert.ToInt32(DropDownList1.SelectedValue);
            
            dal.Insert(student);

            Response.Redirect("~/Views/StudentView");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/StudentView");
        }
    }
}