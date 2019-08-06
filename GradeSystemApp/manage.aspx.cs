using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace GradeSystemApp
{
    public partial class manage : System.Web.UI.Page
    {
        List<GradeDefinition> gradeInfoList;
        List<GradeSystem> gradeSystemList;
        int id;
        int maxMark;
        protected void Page_Load(object sender, EventArgs e)
        {

            id = Convert.ToInt32(Server.UrlDecode(Request.QueryString["Id"]));
            gradeInfoList = GradeDefinition.GetGradeList(id);
            gradeSystemList = GradeSystem.GetGradeSystemList();


            foreach (var obj in gradeSystemList)
            {
                if (obj.GS_id == id)
                {
                    maxMark = obj.maxMark;
                    heading.Text = obj.tilte;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)

        {
            id = Convert.ToInt32(Server.UrlDecode(Request.QueryString["Id"]));

            string[] minInput = Request.Form.GetValues("minInput");

            string[] maxInput = Request.Form.GetValues("maxInput");

            string[] gradeInput = Request.Form.GetValues("gradeInput");

            DataTable dtable = dt();

            for (int i = 0; i <= minInput.Length - 1; i++)

            {
                bool validationStatus = ValidateMinMaxGrade(minInput[i], maxInput[i], gradeInput[i]);

                if (validationStatus)
                {
                    DataRow row1 = dtable.NewRow();
                    row1["gs_id"] = id;
                    row1["minInput"] = minInput[i];
                    row1["maxInput"] = maxInput[i];
                    row1["gradeInput"] = gradeInput[i];

                    dtable.Rows.Add(row1);
                }
                else
                {
                    validation_status.Text = "Validation Error! Data not Saved";
                    return;
                }
            }

            bool insertStatus = GradeDefinition.InsertGradeDefinition(dtable);
            if (insertStatus)
            {
                Response.Redirect("view.aspx?Id="+id);
            }
            else
            {
                validation_status.Text = "Error! Insertion failed";
            }
        }


        protected bool ValidateMinMaxGrade(string minInput, string maxInput, string gradeInput)
        {

            if(minInput == "" || maxInput == "" || gradeInput == "")
            {
                data_status.Text = "All fields are required";
                return false;
            }


            int entered_min = Convert.ToInt32(minInput);
            int entered_max = Convert.ToInt32(maxInput);


            if (gradeInfoList.Any(p => p.Grade == gradeInput))
            {
                data_status.Text = "Grade " + gradeInput + " already exist";
                return false;
            }

            bool minMaxValidationStatus = _MinMaxValidation(gradeInfoList, entered_min, entered_max);
            if (minMaxValidationStatus)
            {
                data_status.Text = "This range interferes with an already existing range";
                return false;
            }

            data_status.Text = "";
            return true;

        }

        private bool _MinMaxValidation(List<GradeDefinition> gradeInfoList, int entered_min, int entered_max)
        {
            foreach (var obj in gradeInfoList)
            {
                if (entered_min >= obj.Min && entered_min < obj.Max || entered_max > obj.Min && entered_max <= obj.Max)
                {
                    return true;
                }
            }
            return false;
        }

        static DataTable dt()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("minInput");
            dt.Columns.Add("maxInput");
            dt.Columns.Add("gradeInput");
            dt.Columns.Add("gs_id");

            return dt;

        }


        public string conString = System.Configuration.ConfigurationManager.ConnectionStrings["GradeInfoConnectionString"].ConnectionString;


        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void view_Click(object sender, EventArgs e)
        {
            Response.Redirect("view.aspx?Id=" + id.ToString());
        }

        
    }
}