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
    public class clsDALTests
    {
        
        //public static bool AddNewTest(int TestAppointmentID,bool TestResult,
        //                                        string Notes ,int CreatedByUserID)
        //{

        //}

        public static int AddNewTest(int TestAppointmentID, bool TestResult,
                                                string Notes, int CreatedByUserID)
        {
            int result = -1;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = @"USE [DVLD]; INSERT INTO [dbo].Tests (TestAppointmentID, TestResult, Notes,CreatedByUserID)
                                                            VALUES (@TestAppointmentID, @TestResult, @Notes,@CreatedByUserID);
                                    SELECT SCOPE_IDENTITY();";

            string Query = @"USE [DVLD];
                            INSERT INTO [dbo].[Tests]
                                       ([TestAppointmentID]
                                       ,[TestResult]
                                       ,[Notes]
                                       ,[CreatedByUserID])
                                 VALUES
                                       (@TestAppointmentID
                                       ,@TestResult 
                                       ,@Notes 
                                       ,@CreatedByUserID); SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            
            sqlCommand.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            sqlCommand.Parameters.AddWithValue("@TestResult", TestResult);
            sqlCommand.Parameters.AddWithValue("@Notes", Notes);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                sqlConnection.Open();
                object obj = sqlCommand.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out var result2))
                {
                    result = result2;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                sqlConnection.Close();
            }

            return result;
        }
        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult,
                                                string Notes, int CreatedByUserID)
        {
            int num = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string cmdText = "USE [DVLD];Update  Users  \r\n                            set PersonID = @PersonID, \r\n                                JobID = @JobID, \r\n                                BranchID = @BranchID, \r\n                                Permissoins = @Permissoins, \r\n                                UserName = @UserName, \r\n                                Password = @Password,\r\n                                Status =@Status\r\n                                where UserID = @UserID";
            string Query = @"USE [DVLD]; UPDATE [dbo].[Users]
                               SET [TestAppointmentID] = @TestAppointmentID
                                  ,[TestResult] = @TestResult
                                  ,[Notes] = @Notes
                                  ,[CreatedByUserID] = @CreatedByUserID
                             WHERE TestID = @TestID";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            
            
            sqlCommand.Parameters.AddWithValue("@UserID", TestID);
            sqlCommand.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            sqlCommand.Parameters.AddWithValue("@TestResult", TestResult);
            sqlCommand.Parameters.AddWithValue("@Notes", Notes);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                sqlConnection.Open();
                num = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

            return num > 0;
        }
        public static bool GetTestInfoByID(int TestID, ref int TestAppointmentID, ref bool TestResult,
                                                ref string Notes, ref int CreatedByUserID)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT * FROM Tests WHERE TestID = @TestID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    result = true;


                    Notes = (string)sqlDataReader["Notes"];
                    TestResult = (bool)sqlDataReader["TestResult"];
                    TestAppointmentID = (int)sqlDataReader["TestAppointmentID"];
                    CreatedByUserID = (int)sqlDataReader["CreatedByUserID"];
                }
                else
                {
                    result = false;
                }

                sqlDataReader.Close();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                sqlConnection.Close();
            }

            return result;
        }
        public static bool IsTested(int TestAppointmentID)
        {
            bool isTest = false;
            bool TestResult = true;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select TestResult from TestAppointments
                         WHERE TestAppointmentID = @TestAppointmentID AND TestResult = @TestResult";

            SqlCommand command = new SqlCommand(query, conn);



            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    isTest = true;
                }


            }
            catch (Exception ex)
            {

            }

            finally
            {
                conn.Close();
            }

            return isTest;
        }


    }
}
