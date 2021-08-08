using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoDemo.Views
{
    public partial class ClassView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Page_Load");

            if (!Page.IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            ClassDal dal = new ClassDal();
            DataTable dt = dal.GetList(0);
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }

    }
}