using DVLD_DataAccessLayerLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerLib
{
    public class clsDALTestAppointments
    {


        public static bool GetTestAppointmentByID(int TestAppointmentID, ref int LocalDrivingLicenseApplicationID, ref int TestTypeID
           , ref DateTime AppointmentDate, ref double PaidFees, ref int CreatedByUserID, ref bool IsLocked)
        {
            bool isFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP (1) [TestTypeID]
      ,[LocalDrivingLicenseApplicationID]
      ,[AppointmentDate]
      ,[PaidFees]
      ,[CreatedByUserID]
      ,[IsLocked]
  FROM [DVLD].[dbo].[TestAppointments] where TestAppointmentID = @TestAppointmentID";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    IsLocked = (bool)reader["IsLocked"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    PaidFees = Convert.ToDouble(reader["CreatedByUserID"]);
                    TestTypeID = (int)reader["TestTypeID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];



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
        public static bool GetTestAppointmentByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID, ref int TestAppointmentID, ref int TestTypeID
            , ref DateTime AppointmentDate, ref double PaidFees, ref int CreatedByUserID, ref bool IsLocked)
        {
            bool isFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP (1) [TestAppointmentID]
      ,[TestTypeID]
      ,[AppointmentDate]
      ,[PaidFees]
      ,[CreatedByUserID]
      ,[IsLocked]
  FROM [DVLD].[dbo].[TestAppointments] where  LocalDrivingLicenseApplicationID= @LocalDrivingLicenseApplicationID";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    IsLocked = (bool)reader["IsLocked"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    PaidFees = Convert.ToDouble(reader["CreatedByUserID"]);
                    TestTypeID = (int)reader["TestTypeID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];



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

        public static int AddNewTestAppointment( int LocalDrivingLicenseApplicationID,  int TestTypeID
           ,  DateTime AppointmentDate,  double PaidFees,  int CreatedByUserID,bool IsLocked)
        {
            int AppointmentID = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[TestAppointments]
           ([TestTypeID]
           ,[LocalDrivingLicenseApplicationID]
           ,[AppointmentDate]
           ,[PaidFees]
           ,[CreatedByUserID]
           ,[IsLocked])
     VALUES
           (@TestTypeID
           ,@LocalDrivingLicenseApplicationID
           ,@AppointmentDate
           ,@PaidFees
           ,@CreatedByUserID
           ,@IsLocked); SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                conn.Open();
                //command.ExecuteNonQuery();

                Object Resulte = command.ExecuteScalar();

                if (Resulte != null && int.TryParse(Resulte.ToString(), out int insertedID))
                {
                    AppointmentID = insertedID;
                }
                
            }
            catch (Exception ex)
            {

            }

            finally
            {
                conn.Close();
            }

            return AppointmentID;

        }
        
        
        public static bool UpdateTestAppointment(int TestAppointmentID,int LocalDrivingLicenseApplicationID, int TestTypeID
           , DateTime AppointmentDate, double PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int effectRows = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[TestAppointments]
                           SET [TestTypeID] = @TestTypeID
                              ,[LocalDrivingLicenseApplicationID] = @LocalDrivingLicenseApplicationID
                              ,[AppointmentDate] = @AppointmentDate
                              ,[PaidFees] = @PaidFees
                              ,[CreatedByUserID] = @CreatedByUserID
                              ,[IsLocked] = @IsLocked
                         WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, conn);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                conn.Open();
                
                effectRows= command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

            }

            finally
            {
                conn.Close();
            }

            return effectRows>0;

        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            int effectRows = -1;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE FROM [dbo].[TestAppointments]
                                WHERE TestAppointmentID = @TestAppointmentID";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                sqlConnection.Open();
                effectRows = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                sqlConnection.Close();
            }

            return effectRows > 0;
        }

        public static bool LockedTestAppointment(int TestAppointmentID,bool IsLocked)
        {
            int effectRows = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[TestAppointments]
                           SET [IsLocked] = @IsLocked
                         WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, conn);


            
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                conn.Open();

                effectRows = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

            }

            finally
            {
                conn.Close();
            }

            return effectRows > 0;
        }
        
        public static bool IsAppointmentLocked(int TestAppointmentID)
        {
            bool isLocked = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select IsLocked from TestAppointments
                         WHERE TestAppointmentID = @TestAppointmentID ";

            SqlCommand command = new SqlCommand(query, conn);



            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();


                    isLocked = true;
                }


            }
            catch (Exception ex)
            {

            }

            finally
            {
                conn.Close();
            }

            return isLocked;
        }
        public static int GetNumberOfTestsSuccessfull(int LocalDrivingLicenseApplicationID)
        {
            bool result = true;
            int count = 0;
                    //string query = @"SELECT count(LocalDrivingLicenseApplication = count(*) 
                    //FROM   TestAppointments   INNER JOIN Tests
                    //                   ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID where TestAppointments.IsLocked = 1 
                    //				  group by (TestAppointments.LocalDrivingLicenseApplicationID )
                    //				  having TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
                    //";

            string query = @"SELECT count(Tests.TestAppointmentID) as LocalDrivingLicense
			FROM  Tests    INNER JOIN TestAppointments on TestAppointments.TestAppointmentID = tests.TestAppointmentID 
			WHERE  TestAppointments.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID ";


            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(query, conn);
            //ApplicationStatus = 1;
            cmd.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", @LocalDrivingLicenseApplicationID);
            

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicense"];
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

            return LocalDrivingLicenseApplicationID;
        }

        public static int GetNumberOfTestsFail(int LocalDrivingLicenseApplicationID)
        {
            bool result = false;
            int count = 0;
            
            string query = @"SELECT count(Tests.TestAppointmentID) as LocalDrivingLicense
			FROM  Tests    INNER JOIN TestAppointments on TestAppointments.TestAppointmentID = tests.TestAppointmentID 
			WHERE  TestAppointments.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID And Tests.TestResult=@result ";


            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(query, conn);
            //ApplicationStatus = 1;
            cmd.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", @LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@result", result);


            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    count = (int)reader["LocalDrivingLicense"];
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

            return count;
        }

        public static DataTable GetAllTestAppointments(int LocalDrivingLicenseApplicationID,byte TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            
            string query = @"SELECT TestAppointments.TestAppointmentID, TestTypes.TestTypeTitle, TestAppointments.AppointmentDate, TestAppointments.PaidFees, TestAppointments.IsLocked
                               FROM     TestAppointments INNER JOIN
                              TestTypes ON TestAppointments.TestTypeID = TestTypes.TestTypeID WHERE LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID And TestAppointments.TestTypeID = @TestTypeID ";

            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            comm.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                conn.Close();

            }

            return dt;

        }

        public static bool IsTested(int AppointmentID)
        {
            return clsDALTests.IsTested(AppointmentID);
        }

    }
}
