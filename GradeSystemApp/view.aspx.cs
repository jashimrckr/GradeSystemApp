using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GradeSystemApp
{
    public partial class view : System.Web.UI.Page
    {
        public string conString = System.Configuration.ConfigurationManager.ConnectionStrings["GradeInfoConnectionString"].ConnectionString;
        List<GradeDefinition> gradeInfoList;
        protected void Page_Load(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(Request.QueryString["Id"]);
            gradeInfoList = GradeDefinition.GetGradeList(id);
            GridView1.DataSource = gradeInfoList;
            GridView1.DataBind();

        }
        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void add_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"];
            Response.Redirect("manage.aspx?Id=" + id);
        }
    }
}