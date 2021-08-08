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
    public partial class Classes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Page_Load");
        }

        public IQueryable<Class> GetClasses()
        {
            var _db = new WebDemo.Models.StudentContext();
            IQueryable<Class> query = _db.Classes;
            System.Diagnostics.Debug.WriteLine(query.ToList().Count());
            return query;
        }
    }
}