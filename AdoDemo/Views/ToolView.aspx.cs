using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoDemo.Views
{
    public partial class ToolView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Page_Load");

            if (!Page.IsPostBack)
            {
                // ddlclass.Items.Add("计算机学院");
                //                ddlclass.Items.Add("经济学院");
                //                ddlclass.Items.Add("文法学院");
                //                ddlclass.SelectedIndex = 0;
                //                ddlclass.Items.Add("软件工程");
                //                ddlclass.Items.Add("计算机科学");
                //                ddlclass.Items.Add("电子学");
                //                ddlclass.Items.Add("微电子");

                setClassDropDownList();
                setStudentDropDownList(ddlclass.Items[0].Value);

                Session["test1"] = "test1";
                ViewState["test2"] = "test2";

                String a = ViewState["test2"].ToString();
            }
            else {
                DateTime d = Calendar1.SelectedDate;

                System.Diagnostics.Debug.WriteLine(d.ToString("MM/dd/yyyy HH:mm:ss"));
            }
        }

        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
//            switch(ddlclass.Text)
//        {
//            case "计算机学院":
//                ddlstudent.Items.Clear();
//                ddlstudent.Items.Add("软件工程");
//                ddlstudent.Items.Add("计算机科学");
//                ddlstudent.Items.Add("电子学");
//                ddlstudent.Items.Add("微电子");
//                break;
//            case "经济学院":
//                ddlstudent.Items.Clear();
//                ddlstudent.Items.Add("金融学");
//                ddlstudent.Items.Add("保险学");
//                ddlstudent.Items.Add("财政学");
//                break;
//            case "法学院":
//                ddlstudent.Items.Clear();
//                ddlstudent.Items.Add("法学");
//                ddlstudent.Items.Add("公共事业管理");
//                ddlstudent.Items.Add("新闻学");
//                break;
//        }


            setStudentDropDownList(ddlclass.SelectedValue);



        }
        public void setClassDropDownList() {

            ClassDal dal = new ClassDal();
            DataTable dt = dal.GetList(0);

            ddlclass.DataSource = dt;
        ddlclass.DataTextField = "classname";
        ddlclass.DataValueField = "classid";
        ddlclass.DataBind();
    }
    public void setStudentDropDownList(string classid)
    {
        StudentDal dal = new StudentDal();
        DataTable dt = dal.GetList(Convert.ToInt32(classid));
        ddlstudent.DataSource = dt;
        ddlstudent.DataTextField = "studentname";
        ddlstudent.DataValueField = "studentid";
        ddlstudent.DataBind();
    }

    }
}