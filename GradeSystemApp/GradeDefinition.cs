using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

     

        public static bool InsertGradeDefinition(DataTable dt)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["GradeInfoConnectionString"].ConnectionString;
   

            StringBuilder sb = new StringBuilder();

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "dbo.GradeDefinition";

                    //[OPTIONAL]: Map the DataTable columns with that of the database table
                    sqlBulkCopy.ColumnMappings.Add("gs_id", "GS_id");
                    sqlBulkCopy.ColumnMappings.Add("minInput", "Min");
                    sqlBulkCopy.ColumnMappings.Add("maxInput", "Max");
                    sqlBulkCopy.ColumnMappings.Add("gradeInput", "Grade");
                    con.Open();
                    try
                    {
                        sqlBulkCopy.WriteToServer(dt);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                    finally
                    {
                        sqlBulkCopy.Close();
                        con.Close();
                    }
                }
            } 
        }

        public static void DeleteGradeDefinition(int id)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["GradeInfoConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("Proc_GradeDefinition_DeleteRow", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GD_id", SqlDbType.Int);
                cmd.Parameters["@GD_id"].Value = id;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}