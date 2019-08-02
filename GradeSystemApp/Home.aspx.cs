using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace GradeSystemApp
{
    public partial class Home : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataSet ds = GetData();
                gradeSystemRepeater.DataSource = ds;
                gradeSystemRepeater.DataBind();
            }

        }

        protected void addGradeSystem_Click(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx");
        }

        protected void view_Click(object sender, EventArgs e)
        {
            string id = (sender as Button).CommandArgument;
            Response.Redirect("view.aspx?Id="+id);
        }

        protected void manage_Click(object sender, EventArgs e)
        {
            string id = (sender as Button).CommandArgument;
            Response.Redirect("manage.aspx?Id="+id);
        }

        public string conString = System.Configuration.ConfigurationManager.ConnectionStrings["GradeInfoConnectionString"].ConnectionString;

        private DataSet GetData()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlDataAdapter da = new SqlDataAdapter("Proc_GradeSystem_GetAll", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        protected void DeleteRow(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as Button).CommandArgument);
            GradeSystem.DeleteGradeSystem(id);
            Response.Redirect("Home.aspx");
            
        }
    }
}