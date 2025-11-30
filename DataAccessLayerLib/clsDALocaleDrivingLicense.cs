using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayerLib
{
    public class clsDALocaleDrivingLicense
    {
        public static bool GetLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            string Query = @"SELECT TOP (1) 
        [ApplicationID]
        ,[LicenseClassID]
    FROM [dbo].[LocalDrivingLicenseApplications] where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID ";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(Query, conn);

            cmd.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", @LocalDrivingLicenseApplicationID);

            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    Reader.Read();
                    isFound = true;
                    // LocalDrivingLicenseApplicationCode = (string)Reader["LocalDrivingLicenseApplicationCode"];
                    //LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];
                    ApplicationID = (int)Reader["ApplicationID"];

                }

            }
            catch (SqlException ex)
            {
                //Console.WriteLine(ex.Message);
            }

            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static bool GetLocalDrivingLicenseApplicationByApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            string Query = @"SELECT TOP (1) 
                            [ApplicationID]
                            ,[LicenseClassID]
                        FROM [DVLD].[dbo].[LocalDrivingLicenseApplications] where ApplicationID =@ApplicationID ";
                                SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

                SqlCommand cmd = new SqlCommand(Query, conn);

                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;
                LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                LicenseClassID = (int)Reader["LicenseClassID"];

                    // LocalDrivingLicenseApplicationCode = (string)Reader["LocalDrivingLicenseApplicationCode"];

                }
                Reader.Close();

            }
            catch (SqlException ex)
            {

            }

            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID,int LicenseClassID)
        {
            bool isUpdate = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[LocalDrivingLicenseApplications]
SET [ApplicationID] = @ApplicationID
    ,[LicenseClassID] = @LicenseClassID
WHERE  LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID
";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


            try
            {
                conn.Open();
                isUpdate = command.ExecuteNonQuery() > 0;
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

        public static int AddNewLocalDrivingLicenseApplication( int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID =-1;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Insert Into  [dbo].[LocalDrivingLicenseApplications]
                                ( [ApplicationID] ,[LicenseClassID]) Values (@ApplicationID,@LicenseClassID);SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


            try
            {
                conn.Open();
                
                object obj = command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out var result2))
                {
                    LocalDrivingLicenseApplicationID = result2;
                }
                
            }
            catch (Exception ex)
            {
                LocalDrivingLicenseApplicationID = -1;
            }

            finally
            {
                conn.Close();
            }


            return LocalDrivingLicenseApplicationID;

        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete [dbo].[LocalDrivingLicenseApplications]
  
                                where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

               

            
        public static bool IsExistLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
            {
                bool isFound = false;

                SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

                string query = @"SELECT Found=1 FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID ";
                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    isFound = reader.HasRows;

                    reader.Close();
                }

                catch (Exception ex)
                {
                    isFound = false;
                }
                finally
                {
                    conn.Close();
                }

                return isFound;
            }

        public static DataTable GetAllLocalDrivingLicenseApplication()
            {
                DataTable dtLocalDrivingLicenseApplication = new DataTable();
                SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = "  Select * From ViewLocalDrivingLicenseApplications order by Application_Status Asc ";
                    
                string Complixityquery = @" SELECT Applications.ApplicationID, LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, 
	                                        (Case when People.LastName = null  then People.FirstName+'  '+ People.SecondName+'  '+ People.ThirdName
	                                        else
	                                        People.FirstName+ '  '+People.SecondName+ '  '+People.ThirdName+ '  '+People.LastName end)
	                                        as FullName, LicenseClasses.ClassName, 
	                                        (Case When Applications.ApplicationStatus = 1 Then 'New' WHEN Applications.ApplicationStatus = 2 Then 'Canceled' else 'Completed' end) as Application_Status
	                                        ,Users.UserName
	                                        FROM     Applications INNER JOIN
					                                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN
                                                            LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID INNER JOIN
                                                            People ON Applications.ApplicantPersonID = People.PersonID INNER JOIN
                                                            Users ON Applications.CreatedByUserID = Users.UserID 
                                            ";
                    
                SqlCommand cmd = new SqlCommand(Complixityquery, conn);

                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        dtLocalDrivingLicenseApplication.Load(reader);
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

                return dtLocalDrivingLicenseApplication;
            }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID)
        {
            if (DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID))
            {
                return clsDAApplicationData.DeleteApplication(ApplicationID);
            }
            return false;
        }

    }
}


