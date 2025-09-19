using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
 
    public class clsDAPersons
    {
        public static bool GetPersonInfoByID(int ID, ref string FirstName, ref string LastName, ref string Email, ref string Phon, ref int Address, ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath, ref string Gender)
        {
            bool result = false;
            sqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT * FROM Persons WHERE PersonID = @PersonID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PersonID", ID);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    result = true;
                    FirstName = (string)sqlDataReader["FirstName"];
                    LastName = (string)sqlDataReader["LastName"];
                    Email = (string)sqlDataReader["Email"];
                    Phon = (string)sqlDataReader["Phon"];
                    Address = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Address"));
                    DateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                    if (sqlDataReader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)sqlDataReader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }
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

        public static bool GetPersonInfoByID(string FirstName, ref int ID, ref string LastName, ref string Email, ref string Phon, ref int Address, ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath, ref string Gender)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT * FROM Persons WHERE FirstName = @FirstName";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    result = true;
                    ID = (int)sqlDataReader["ID"];
                    LastName = (string)sqlDataReader["LastName"];
                    Email = (string)sqlDataReader["Email"];
                    Phon = (string)sqlDataReader["Phon"];
                    Address = (int)sqlDataReader["Address"];
                    DateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                    CountryID = (int)sqlDataReader["CountryID"];
                    if (sqlDataReader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)sqlDataReader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }
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

        public static int AddNewPerson(string FirstName, string LastName, string Email, string Phon, int Address, DateTime DateOfBirth, int CountryID, string ImagePath, string Gender)
        {
            int result = -1;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "INSERT INTO [dbo].[Persons]\r\n           ([FirstName]\r\n           ,[LastName]\r\n           ,[Gender]\r\n           ,[Phon]\r\n           ,[Address]\r\n           ,[Email]\r\n           ,[ImagePath]\r\n           ,[DateOfBirth])\r\n     VALUES\r\n           (@FirstName,\r\n           @LastName,\r\n           @Gender, \r\n           @Phon,\r\n           @Address,\r\n           @Email,\r\n           @ImagePath,\r\n           @DateOfBirth);SELECT SCOPE_IDENTITY();";
            Gender = "Male";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", LastName);
            sqlCommand.Parameters.AddWithValue("@Email", Email);
            sqlCommand.Parameters.AddWithValue("@Phon", Phon);
            sqlCommand.Parameters.AddWithValue("@Address", Address);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@Gender", Gender);
            if (ImagePath != "" && ImagePath != null)
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }

            try
            {
                sqlConnection.Open();
                object obj = sqlCommand.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out var result2))
                {
                    result = result2;
                }
            }
            catch (SqlException)
            {
            }
            finally
            {
                sqlConnection.Close();
            }

            return result;
        }

        public static bool UpdatePerson(int ID, string FirstName, string LastName, string Email, string Phon, int Address, DateTime DateOfBirth, int CountryID, string ImagePath, string Gender)
        {
            int num = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "Update  Persons  \r\n                            set FirstName = @FirstName, \r\n                                LastName = @LastName, \r\n                                Email = @Email, \r\n                                Phon = @Phon, \r\n                                Address = @Address, \r\n                                DateOfBirth = @DateOfBirth,\r\n                                ImagePath =@ImagePath\r\n                                where PersonID = @PersonID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PersonID", ID);
            sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", LastName);
            sqlCommand.Parameters.AddWithValue("@Email", Email);
            sqlCommand.Parameters.AddWithValue("@Phon", Phon);
            sqlCommand.Parameters.AddWithValue("@Address", Address);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@Gender", Gender);
            if (ImagePath != "" && ImagePath != null)
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }

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

        public static DataTable GetAllPersons()
        {
            DataTable dataTable = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT * FROM Persons";
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

        public static bool DeletePerson(int PersonID)
        {
            int num = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "Delete Persons \r\n                                where PersonID = @PersonID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
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

        public static bool IsPersonExist(int ID)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT Found=1 FROM Persons WHERE PersonID = @PersonID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PersonID", ID);
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
    }


