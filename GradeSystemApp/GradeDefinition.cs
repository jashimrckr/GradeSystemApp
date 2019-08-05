using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GradeSystemApp
{
    public class GradeDefinition
    {
        public int GD_id { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public string Grade { get; set; }

        public GradeDefinition(int gd_id, int minMark, int maxMark, string Grade)
        {
            this.GD_id = gd_id;
            this.Min = minMark;
            this.Max = maxMark;
            this.Grade = Grade;
        }

        public static List<GradeDefinition> GetGradeList(int id)
        {
            List<GradeDefinition> gradeInfoList = new List<GradeDefinition>();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["GradeInfoConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conString))
            {

                SqlCommand cmd = new SqlCommand("Proc_GradeDefinition_GetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GS_id", SqlDbType.Int).Value = id;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    gradeInfoList.Add(new GradeDefinition(Convert.ToInt32(reader["GD_id"]), Convert.ToInt32(reader["Min"]), Convert.ToInt32(reader["Max"]), reader["Grade"].ToString()));
                }
                reader.Close();
                con.Close();
            }

            return gradeInfoList;
        }

        public static bool InsertGradeDefinition(int id, int entered_min, int entered_max, string entered_grade)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["GradeInfoConnectionString"].ConnectionString;
            int rowCount = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {

                SqlCommand cmd = new SqlCommand("Proc_GradeDefinition_InsertGradeDefinition", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@GS_id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Min", SqlDbType.Int).Value = entered_min;
                cmd.Parameters.Add("@Max", SqlDbType.Int).Value = entered_max;
                cmd.Parameters.Add("@Grade", SqlDbType.NVarChar).Value = entered_grade;
            

                con.Open();
                rowCount = cmd.ExecuteNonQuery();
                con.Close();
            }
            if (rowCount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}