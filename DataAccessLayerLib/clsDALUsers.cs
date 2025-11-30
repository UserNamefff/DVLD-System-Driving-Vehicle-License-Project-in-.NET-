using DVLD_DataAccessLayerLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayerLib
{
    public class clsDALUsers
    {
        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName, ref string Password,ref bool IsActive, ref int Permissoins)
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

                    
                    Password = (string)sqlDataReader["Password"];
                    UserName = (string)sqlDataReader["UserName"];
                    PersonID = (int)sqlDataReader["PersonID"];
                    IsActive = (bool)sqlDataReader["IsActive"];
                    Permissoins = (int)sqlDataReader["Permissions"];
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
        public static bool GetUserInfoByPersonID(  int PersonID, ref int UserID, ref string UserName, ref string Password, ref bool IsActive, ref int Permissoins)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "USE [DVLD];SELECT * FROM Users WHERE PersonID = @PersonID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    result = true;


                    Password = (string)sqlDataReader["Password"];
                    UserName = (string)sqlDataReader["UserName"];
                    UserID = (int)sqlDataReader["UserID"];
                    IsActive = (bool)sqlDataReader["IsActive"];
                    Permissoins = (int)sqlDataReader["Permissions"];
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

        public static bool GetUserInfoByUserName(string UserName, ref int PersonID, ref int UserID, ref string Password,ref bool IsActive, ref int Permissoins)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "USE [DVLD];SELECT * FROM Users WHERE UserName = @UserName";
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

        public static bool GetUserInfoByUserNameAndPassword(string UserName, string Password, ref int PersonID, ref int UserID, ref bool IsActive,ref int Permissoins)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "USE [DVLD];SELECT * FROM Users WHERE UserName = @UserName And Password = @Password ";
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

        public static int AddNewUser(int PersonID, string UserName, string Password,bool IsActive, int Permissoins)
        {
            int result = -1;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = @"USE [DVLD]; INSERT INTO [dbo].Users (PersonID, UserName, Password,IsActive, Permissions)
                                                            VALUES (@PersonID, @UserName, @Password,@IsActive, @Permissions);
                                    SELECT SCOPE_IDENTITY();";

            string Query = @"USE [DVLD];
                            INSERT INTO [dbo].[Users]
                                       ([PersonID]
                                       ,[UserName]
                                       ,[Password]
                                       ,[IsActive]
                                       ,[Permissions])
                                 VALUES
                                       (@PersonID
                                       ,@UserName
                                       ,@Password
                                       ,@IsActive
                                       ,@Permissions); SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
            
            sqlCommand.Parameters.AddWithValue("@Permissions", Permissoins);
            sqlCommand.Parameters.AddWithValue("@UserName", UserName);
            sqlCommand.Parameters.AddWithValue("@Password", Password);
            sqlCommand.Parameters.AddWithValue("@IsActive", IsActive);
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

        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive, int Permissoins)
        {
            int num = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string cmdText = "USE [DVLD];Update  Users  \r\n                            set PersonID = @PersonID, \r\n                                JobID = @JobID, \r\n                                BranchID = @BranchID, \r\n                                Permissoins = @Permissoins, \r\n                                UserName = @UserName, \r\n                                Password = @Password,\r\n                                Status =@Status\r\n                                where UserID = @UserID";
            string Query = @"USE [DVLD]; UPDATE [dbo].[Users]
                               SET [PersonID] = @PersonID
                                  ,[UserName] = @UserName
                                  ,[Password] = @Password
                                  ,[IsActive] = @IsActive
                                  ,[Permissions] = @Permissions
                             WHERE UserID = @UserID";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
            sqlCommand.Parameters.AddWithValue("@Permissions", Permissoins);
            sqlCommand.Parameters.AddWithValue("@UserName", UserName);
            sqlCommand.Parameters.AddWithValue("@Password", Password);
            sqlCommand.Parameters.AddWithValue("@IsActive", IsActive);

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
            string cmdText = @"USE [DVLD]; SELECT Users.UserID, Users.PersonID,  (CASE When People.LastName = NULL  
			THEN
		 People.FirstName+' '+ People.SecondName +' '+People.ThirdName 
		 else People.SecondName +' '+People.ThirdName+' '+ People.LastName end)AS FullName ,Users.UserName, Users.IsActive, Users.Permissions

FROM     Users INNER JOIN
                  People ON Users.PersonID = People.PersonID";
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
            string cmdText = "USE [DVLD];Update Users set Password =@NewUserPassword,UserName=@UserName Where UserID =@UserID ";
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
            string cmdText = "USE [DVLD];Delete Users \r\n                                where UserID = @UserID";
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
            string cmdText = "USE [DVLD];SELECT Found=1 FROM Users WHERE UserID = @UserID";
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

        public static bool IsUserExist(string UserName)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "USE [DVLD];SELECT Found=1 FROM Users WHERE UserName = @UserName";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UserName", UserName);
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
            string cmdText = "USE [DVLD];SELECT Found=1 FROM Users WHERE PersonID = @PersonID";
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
            string cmdText = "USE [DVLD];INSERT INTO Users (UserID, LoginLogoutDate, LoginTime)\r\n                             VALUES (@UserID, @LoginLogoutDate, @LoginTime);\r\n                             SELECT SCOPE_IDENTITY();";
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
            string cmdText = "USE [DVLD];Update  RegisterUsers  \r\n                            set LogoutTime = @LogoutTime, \r\n                                where UserID = @UserID";
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
            string cmdText = "USE [DVLD];SELECT *FROM RegisterUsers";
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


        public static bool ChangeUserPermissions(int UserID, int Permissions)
        {
            //Change User Permissions will be here .....

            return false;
        }





    }

}