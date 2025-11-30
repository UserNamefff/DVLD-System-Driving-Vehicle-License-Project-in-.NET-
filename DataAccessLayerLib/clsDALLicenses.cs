using DVLD_DataAccessLayerLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayerLib
{
    public class clsDALLicenses
    {


        public static bool GetLicenseByID(int licenseID,ref int ApplicationID, ref int DriverID, ref int LicenseClass,
                        ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
                        ref double PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {

            
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT top(1) FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("LicenseID",@licenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    

                    ApplicationID = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IssueReason = (byte)reader["IssueReason"];
                    IsActive = (bool)reader["IsActive"];
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
            
        }

        public static bool GetLicenseByApplicationID(int ApplicationID ,ref int licenseID, ref int DriverID, ref int LicenseClass,
                        ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
                        ref double PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {

            
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT top(1) FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("LicenseID", @ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    licenseID = (int)reader["LicenseID"];
                    //ApplicationID = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IssueReason = (byte)reader["IssueReason"];
                    IsActive = (bool)reader["IsActive"];
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
            
        }

        public static bool GetLicenseByDrivreID(int DriverID  ,ref int licenseID, ref int ApplicationID, ref int LicenseClass,
                        ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
                        ref double PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {

            
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT top(1) FROM Licenses WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("DriverID", @DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;


                    licenseID = (int)reader["LicenseID"];
                    ApplicationID = (int)reader["LicenseID"];
                    //DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IssueReason = (byte)reader["IssueReason"];
                    IsActive = (bool)reader["IsActive"];
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
            
        }

        

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass,
                        DateTime IssueDate, DateTime ExpirationDate, string Notes,
                        double PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            
            //this function will return the new person id if succeeded and -1 if not.
            int licenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[Licenses]
                               ([ApplicationID],[DriverID]
                               ,[LicenseClass]
                               ,[IssueDate]
                               ,[ExpirationDate]
                               ,[Notes]
                               ,[PaidFees]
                               ,[IsActive]
                               ,[IssueReason]
                               ,[CreatedByUserID])
                         VALUES
                               (@ApplicationID
                               ,@DriverID
                               ,@LicenseClass
                               ,@IssueDate
                               ,@ExpirationDate
                               ,@Notes
                               ,@PaidFees
                               ,@IsActive
                               ,@IssueReason
                               ,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            //ApplicationStatus = 1;
            command.Parameters.AddWithValue("@ApplicationID ", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@PaidFees ", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    licenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return licenseID;
        }


        public static bool UpdateLicense(int licenseID, int ApplicationID, int DriverID, int LicenseClass,
                        DateTime IssueDate, DateTime ExpirationDate, string Notes,
                        double PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Licenses]
                               SET [LicenseID] = @LicenseID
                                  ,[DriverID] = @DriverID
                                  ,[LicenseClass] = @LicenseClass
                                  ,[IssueDate] = @IssueDate
                                  ,[ExpirationDate] = @ExpirationDate
                                  ,[Notes] = @Notes
                                  ,[PaidFees] = @PaidFees
                                  ,[IsActive] = @IsActive
                                  ,[IssueReason] = @IssueReason
                                  ,[CreatedByUserID] = @CreatedByUserID
                             WHERE LicenseID = @Licenses;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID ", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@PaidFees ", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteLicense(int LicenseID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Licenses 
                                where LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static DataTable GetAllLicenseForPerson(int PersonID)
        
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Licenses WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool IsIssuedLicenseByApplication(int ApplicationID)
        {
            bool IsIssued = false;
            

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            /*string query = @"SELECT  top (1) *
FROM    Licenses  INNER JOIN Applications
                   ON Applications.LicenseID = Licenses.LicenseID where Licenses.ApplicationID = = @ApplicationID    ";
            */
            string query = @"SELECT  top (1) *
FROM    Licenses   where ApplicationID =  @ApplicationID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            //ApplicationStatus = 1;
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                IsIssued = (reader.HasRows);
                
                    
                reader.Close();
            }
            catch (Exception ex)
            {
                IsIssued = false;
            }
            finally
            {
                conn.Close();
            }



            return IsIssued;

        }

    }
}
