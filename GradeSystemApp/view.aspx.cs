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
            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                gradeInfoList = GradeDefinition.GetGradeList(id);
                GridView1.DataSource = gradeInfoList;
                GridView1.DataBind();
            }

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

        protected void delete_btn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                int GD_id = Convert.ToInt32((sender as Button).CommandArgument);
                SqlCommand cmd = new SqlCommand("Proc_GradeDefinition_DeleteRow", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GD_id", SqlDbType.Int);
                cmd.Parameters["@GD_id"].Value = GD_id;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            string id = Request.QueryString["Id"];
            Response.Redirect("view.aspx?Id=" + id);
        }
    }
}