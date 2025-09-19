using DataAccessLayerLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerLib
{
    public class clsUsersAccessData
    {
        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref int Permissoins, ref int JobID, ref int BranchID, ref bool Status)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT * FROM Users WHERE UserID = @UserID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    result = true;
                    JobID = (int)sqlDataReader["JobID"];
                    BranchID = (int)sqlDataReader["BranchID"];
                    Permissoins = (int)sqlDataReader["Permissoins"];
                    Password = (string)sqlDataReader["Password"];
                    UserName = (string)sqlDataReader["UserName"];
                    PersonID = (int)sqlDataReader["PersonID"];
                    string text = (string)sqlDataReader["Status"];
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
        
        
        
        public static bool GetUserInfoByUserName(string UserName, ref int PersonID, ref int UserID, ref string Password, ref int Permissoins, ref int JobID, ref int BranchID, ref bool Status)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT * FROM Users WHERE UserName = @UserName";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UserName", UserName);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    result = true;
                    UserID = (int)sqlDataReader["UserID"];
                    JobID = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("JobID"));
                    BranchID = (int)sqlDataReader["BranchID"];
                    Permissoins = (int)sqlDataReader["Permissoins"];
                    Password = (string)sqlDataReader["Password"];
                    UserName = (string)sqlDataReader["UserName"];
                    PersonID = (int)sqlDataReader["PersonID"];
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

        public static bool GetUserInfoByUserNameAndPassword(string UserName, string Password, ref int PersonID, ref int UserID, ref int Permissoins, ref int JobID, ref int BranchID, ref bool Status)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT * FROM Users WHERE UserName = @UserName And Password = @Password ";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UserName", UserName);
            sqlCommand.Parameters.AddWithValue("@Password", Password);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    result = true;
                    UserID = (int)sqlDataReader["UserID"];
                    JobID = (int)sqlDataReader["JobID"];
                    BranchID = (int)sqlDataReader["BranchID"];
                    Permissoins = (int)sqlDataReader["Permissoins"];
                    PersonID = (int)sqlDataReader["PersonID"];
                    string @string = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Status"));
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

        public static int AddNewUser(int PersonID, string UserName, string Password, int Permissoins, int JobID, int BranchID, bool Status)
        {
            int result = -1;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "INSERT INTO Users (PersonID, UserName, Password, Permissoins, JobID,BranchID,Status)\r\n                             VALUES (@PersonID, @UserName, @Password, @Permissoins, @JobID,@BranchID,@Status);\r\n                             SELECT SCOPE_IDENTITY();";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
            sqlCommand.Parameters.AddWithValue("@JobID", JobID);
            sqlCommand.Parameters.AddWithValue("@BranchID", BranchID);
            sqlCommand.Parameters.AddWithValue("@Permissoins", Permissoins);
            sqlCommand.Parameters.AddWithValue("@UserName", UserName);
            sqlCommand.Parameters.AddWithValue("@Password", Password);
            sqlCommand.Parameters.AddWithValue("@Status", Status);
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

        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, int Permissoins, int JobID, int BranchID, bool Status)
        {
            int num = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "Update  Users  \r\n                            set PersonID = @PersonID, \r\n                                JobID = @JobID, \r\n                                BranchID = @BranchID, \r\n                                Permissoins = @Permissoins, \r\n                                UserName = @UserName, \r\n                                Password = @Password,\r\n                                Status =@Status\r\n                                where UserID = @UserID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
            sqlCommand.Parameters.AddWithValue("@JobID", JobID);
            sqlCommand.Parameters.AddWithValue("@BranchID", BranchID);
            sqlCommand.Parameters.AddWithValue("@Permissoins", Permissoins);
            sqlCommand.Parameters.AddWithValue("@UserName", UserName);
            sqlCommand.Parameters.AddWithValue("@Password", Password);
            sqlCommand.Parameters.AddWithValue("@Status", Status);
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

        public static DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT Users.UserID, Persons.FirstName, Persons.LastName, Users.UserName, Users.Password, Users.Status, Users.Permissoins, Jobs.JobName, Branches.BranchName\r\n                            FROM     Users INNER JOIN  Persons ON Users.PersonID = Persons.PersonID INNER JOIN\r\n                              Jobs ON Users.JobID = Jobs.ID INNER Join  Branches ON Users.BranchID = Branches.BranchID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    dataTable.Load(sqlDataReader);
                }

                sqlDataReader.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                sqlConnection.Close();
            }

            return dataTable;
        }

        public static bool ChangeUserName(int UserID, string UserName)
        {
            return false;
        }

        public static bool ChangeUserPassword(int UserID, string UserName, string NewUserPassword)
        {
            bool result = false;
            string cmdText = "Update Users set Password =@NewUserPassword,UserName=@UserName Where UserID =@UserID ";
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            sqlCommand.Parameters.AddWithValue("@Password", NewUserPassword);
            sqlCommand.Parameters.AddWithValue("@UserName", UserName);
            try
            {
                sqlConnection.Open();
                result = sqlCommand.ExecuteNonQuery() > 0;
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

        public static bool DeleteUser(int UserID)
        {
            int num = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "Delete Users \r\n                                where UserID = @UserID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                sqlConnection.Open();
                num = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                sqlConnection.Close();
            }

            return num > 0;
        }

        public static bool IsUserExist(int ID)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT Found=1 FROM Users WHERE UserID = @UserID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UserID", ID);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                result = sqlDataReader.HasRows;
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

        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                result = sqlDataReader.HasRows;
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

        public static int RegisterLoginLogout(int UserID, DateTime LoginLogoutDate, TimeSpan Time)
        {
            int result = -1;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "INSERT INTO Users (UserID, LoginLogoutDate, LoginTime)\r\n                             VALUES (@UserID, @LoginLogoutDate, @LoginTime);\r\n                             SELECT SCOPE_IDENTITY();";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@LoginLogoutDate", LoginLogoutDate);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            sqlCommand.Parameters.AddWithValue("@LoginTime", Time);
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

        public static bool UpdateLoguotTime(int UserID, TimeSpan LogoutTime)
        {
            int num = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "Update  RegisterUsers  \r\n                            set LogoutTime = @LogoutTime, \r\n                                where UserID = @UserID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            sqlCommand.Parameters.AddWithValue("@LogoutTime", LogoutTime);
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

        public static DataTable GetAllRegisterLoginLogout()
        {
            DataTable dataTable = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT *FROM RegisterUsers";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    dataTable.Load(sqlDataReader);
                }

                sqlDataReader.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                sqlConnection.Close();
            }

            return dataTable;
        }
    }

}