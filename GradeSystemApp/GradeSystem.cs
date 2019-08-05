using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GradeSystemApp
{
    public class GradeSystem
    {
        public int GS_id;
        public string tilte { get; set; }
        public int maxMark { get; set; }

        public GradeSystem(int gs_id, string Title, int MaxMark)
        {
            this.GS_id = gs_id;
            this.tilte = Title;
            this.maxMark = MaxMark;
        }

        public static List<GradeSystem> GetGradeSystemList()
        {
            List<GradeSystem> gradeSystemList = new List<GradeSystem>();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["GradeInfoConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("Proc_GradeSystem_GetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    gradeSystemList.Add(new GradeSystem(Convert.ToInt32(reader["GS_id"]), reader["GradeSystemName"].ToString(), Convert.ToInt32(reader["MaxMark"])));
                }
                reader.Close();
                con.Close();
            }

            return gradeSystemList;
        }

        public static bool InsertGradeSystem( string entered_name, int entered_max)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["GradeInfoConnectionString"].ConnectionString;
            int rowCount = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {

                SqlCommand cmd = new SqlCommand("Proc_GradeSystem_InsertGradeSystem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("@GradeSystemName", SqlDbType.NVarChar).Value = entered_name;
                cmd.Parameters.Add("@MaxMark", SqlDbType.Int).Value = entered_max;

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

        public static void DeleteGradeSystem(int id)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["GradeInfoConnectionString"].ConnectionString;
            
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("Proc_GradeSystem_DeleteGradeSystem", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GS_id", SqlDbType.Int);
                cmd.Parameters["@GS_id"].Value = id;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
           
        }
    }
}