using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GradeSystemApp
{
    public partial class add : System.Web.UI.Page
    {

        List<GradeSystem> gradeSystemList;

        protected void Page_Load(object sender, EventArgs e)
        {
            gradeSystemList = GradeSystem.GetGradeSystemList();
        }

        protected void SaveGradeSystem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                string entered_name = gradeTitle.Text.ToUpper();
                int entered_max = Convert.ToInt32(maxMark.Text);

                if (gradeSystemList.Any(p => p.tilte == entered_name))
                {
                    data_status.Text = "Grade " + entered_name + " already exist";
                    return;
                }

                bool insertStatus = GradeSystem.InsertGradeSystem(entered_name, entered_max);
                if (insertStatus)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    data_status.Text = "Error! Insertion failed";
                }

            }
        }

        protected void TitleValidation(object source, ServerValidateEventArgs args)
        {
            CustomValidator valid = source as CustomValidator;
            int number;
            bool isNumber = int.TryParse(args.Value, out number);

            if (isNumber || args.Value == "")
            {
                args.IsValid = false;
                valid.ErrorMessage = "Please enter a valid Grade system Name";
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void MaxMarkValidation(object source, ServerValidateEventArgs args)
        {
            CustomValidator valid = source as CustomValidator;
            int number;
            bool isNumber = int.TryParse(args.Value, out number);

            if (isNumber || args.Value != "")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
                valid.ErrorMessage = "Please enter a valid Maximum Mark";
            }
        }
    }
}