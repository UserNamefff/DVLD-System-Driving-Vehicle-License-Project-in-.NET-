using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayerLib
{
    public class clsDALApplicationTypes
    {
        public static bool GetApplicationTypeByID(int ApplicationTypeID,ref string ApplicationTypeTitle,ref double ApplicationFees)
        {
            bool isFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //string query = @"Select *from [dbo].ApplicationTypes Where ApplicationTypeID = @ApplicationTypeID";
            string query = @"SELECT *
  FROM [dbo].[ApplicationTypes] where
 ApplicationTypeID = @ApplicationTypeID";

            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            
            try
            {
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();



                if (reader.Read()) 
                {
                    isFound = true;
                    ApplicationTypeTitle = reader["ApplicationTypeTitle"].ToString();
                    ApplicationFees = Convert.ToDouble(reader["ApplicationFees"]);

                }

                reader.Close();
            }
            catch (Exception ex) 
            {
                
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }
        public static bool GetApplicationTypeByTitle( string ApplicationTypeTitle,ref int ApplicationTypeID, ref double ApplicationFees)
        {
            bool isFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //string query = @"Select *from [dbo].ApplicationTypes Where ApplicationTypeID = @ApplicationTypeID";
            string query = @"SELECT top(1)
  FROM [dbo].[ApplicationTypes] where
 ApplicationTypeTitle = @ApplicationTypeTitle";

            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            
            try
            {
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();



                if (reader.Read()) 
                {
                    isFound = true;
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    //ApplicationTypeTitle = reader["ApplicationTypeTitle"].ToString();
                    ApplicationFees = Convert.ToDouble(reader["ApplicationFees"]);

                }

                reader.Close();
            }
            catch (Exception ex) 
            {
                
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }
        //[ApplicationTypeID]
        //[ApplicationTypeTitle]
        //[ApplicationFees]


        public static int AddNewApplicationType(  string ApplicationTypeTitle,  double ApplicationFees)
        {
            int ApplicationTypeID = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Insert into ApplicationTypes (ApplicationTypeTitle,ApplicationFees) Values (@ApplicationTypeTitle,@ApplicationFees)";

            SqlCommand comm = new SqlCommand(query, conn);

            try
            {
                ApplicationTypeID = comm.ExecuteNonQuery();
                conn.Open();
                //command.ExecuteNonQuery();

                Object Resulte = comm.ExecuteScalar();

                if (Resulte != null && int.TryParse(Resulte.ToString(), out int insertedID))
                {
                    ApplicationTypeID = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return ApplicationTypeID;
        }


        public static bool UpdateApplicationType(int ApplicationTypeID,string ApplicationTypeTitle, double ApplicationFees)
        {
            bool isUpdate = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDAte  ApplicationTypes SET  ApplicationTypeTitle= @ApplicationTypeTitle ,ApplicationFees = @ApplicationFees Where ApplicationTypeID = @ApplicationTypeID ";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);


            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                isUpdate = true;
            }
            catch (Exception ex)
            {
                isUpdate = false;
            }

            finally
            {
                conn.Close();
            }


            return isUpdate;

        }




        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Select *from [dbo].ApplicationTypes ";

            SqlCommand comm = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                    reader.Close();
                    conn.Close();

                    return dt;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        

    }
}
