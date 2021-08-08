using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDemo.Models;

namespace WebDemo.Views
{
    public partial class AddNewStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Page_Load");

            if (!Page.IsPostBack)
            {
                var _db = new WebDemo.Models.StudentContext();
                IQueryable<Class> query = _db.Classes;
                List<Class> data = query.ToList<Class>();

                DropDownList1.Items.Clear();
                DropDownList1.DataSource = data;
                DropDownList1.DataTextField = "ClassName";
                DropDownList1.DataValueField = "ClassID";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("选择", "0"));
            }
        }

            protected void Button1_Click(object sender, EventArgs e)
        {
            var _db = new WebDemo.Models.StudentContext();
            Student student = new Student();
            student.StudentName = TextBox1.Text;
            student.Address = TextBox2.Text;
            student.ClassID = Convert.ToInt32(DropDownList1.SelectedValue);
            _db.Students.Add(student);
            _db.SaveChanges();
            Response.Redirect("~/Views/Students");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Students");
        }
    }
}