using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void view_Click(object sender, EventArgs e)
        {
            Response.Redirect("view.aspx?Id=" + id.ToString());
        }

        public string conString = System.Configuration.ConfigurationManager.ConnectionStrings["GradeInfoConnectionString"].ConnectionString;

        protected void save_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                int entered_min = Convert.ToInt32(min.Text);
                int entered_max = Convert.ToInt32(max.Text);
                string entered_grade = grade.Text.ToUpper();

                if (gradeInfoList.Any(p => p.Grade == entered_grade))
                {
                    data_status.Text = "Grade " + entered_grade + " already exist";
                    return;
                }

                bool minMaxValidationStatus = _MinMaxValidation(gradeInfoList, entered_min, entered_max);
                if (minMaxValidationStatus)
                {
                    data_status.Text = "This range interferes with an already existing range";
                    return;
                }

                bool insertStatus = GradeDefinition.InsertGradeDefinition(id, entered_min, entered_max, entered_grade);
                if (insertStatus)
                {
                    data_status.Text = "Data Saved Successfully";
                }
                else
                {
                    data_status.Text = "Error! Insertion failed";
                }

            }
            else
            {
                data_status.Text = "Validation Error! Data Not Saved";
            }
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

        protected void MinValidation(object source, ServerValidateEventArgs args)
        {
            CustomValidator valid = source as CustomValidator;
            int number;
            bool isNumber = int.TryParse(args.Value, out number);

            if (isNumber && args.Value != "")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
                valid.ErrorMessage = "Please enter a valid Minimum Mark";
            }
        }

        protected void MaxValidation(object source, ServerValidateEventArgs args)
        {

            CustomValidator valid = source as CustomValidator;
      
            int number;
            bool isNumber = int.TryParse(args.Value, out number);
   
            if (isNumber || args.Value != "")
            {   
                if (number > maxMark)
                {
                    args.IsValid = false;
                    valid.ErrorMessage = "Maximum Mark defined for this Grade System is " + maxMark;
                }
            }
            else
            {
                args.IsValid = false;
                valid.ErrorMessage = "Please enter a valid Maximum Mark";
            }
        }

        protected void GradeValidation(object source, ServerValidateEventArgs args)
        {
            CustomValidator valid = source as CustomValidator;
            int number;
            bool isNumber = int.TryParse(args.Value, out number);

            if (isNumber || args.Value == "")
            {
                args.IsValid = false;
                valid.ErrorMessage = "Please enter a valid Grade";
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}