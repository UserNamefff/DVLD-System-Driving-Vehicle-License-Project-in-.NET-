using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerLib
{

    public class clsDAPeople
    {
        
        public static bool GetPersonInfoByID(int ID, ref string FirstName, ref string LastName,ref string Email, ref string Phon, ref int Address, ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath, ref string Gender,ref string NationalNO )
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT * FROM People WHERE PeopleID = @PeopleID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PeopleID", ID);
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

        public static bool GetPersonInfoByID(string FirstName, ref int ID, ref string FullName, ref string Email, ref string Phon, ref int Address, ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath, ref string Gender, ref string NationalNO)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT * FROM People WHERE FirstName = @FirstName";
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
                   
                    FullName = (FirstName +(string)sqlDataReader["SecondName"]+(string)sqlDataReader["ThirdName"] + (string)sqlDataReader["LastName"]).ToString();
                    
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

        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName, string Email, string Phon, int Address, DateTime DateOfBirth, int CountryID, string ImagePath, string Gender,  string NationalNO)
        {
            int result = -1;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[People]
           ([NationalNo]
           ,[FirstName]
           ,[SecondName]
           ,[ThirdName]
           ,[LastName]
           ,[DateOfBirth]
           ,[Gendor]
           ,[Address]
           ,[Phone]
           ,[Email]
           ,[CountryID]
           ,[ImagePath])
     VALUES
           (NationalNo
           ,FirstName
           ,SecondName
           ,ThirdName
           ,LastName
           ,DateOfBirth
           ,Gendor
           ,Address
           ,Phone
           ,Email
           ,CountryID
           ,ImagePath)";


            Gender = "Male";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
            sqlCommand.Parameters.AddWithValue("@ThirdName", ThirdName);
            
            sqlCommand.Parameters.AddWithValue("@SecondName", SecondName);
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

        public static bool UpdatePerson(int ID, string FirstName, string SecondName, string ThirdName, string LastName, string Email, string Phon, int Address, DateTime DateOfBirth, int CountryID, string ImagePath, string Gender,  string NationalNO)
        {
            int num = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[People]
   SET [NationalNo] = @NationalNo	
      ,[FirstName] =  @FirstName	
      ,[SecondName] = @SecondName	
      ,[ThirdName] =  @ThirdName	
      ,[LastName] =	  @LastName		
      ,[DateOfBirth]= @DateOfBirth 
      ,[Gendor] =		@Gendor		
      ,[Address] = @Address			
      ,[Phone] = @Phone				
      ,[Email] = @Email				
      ,[CountryID] = CountryID
      ,[ImagePath] = @ImagePath";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PeopleID", ID);
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


        public static DataTable GetAllPeople()
        {
            DataTable dataTable = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT * FROM People";
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

        public static bool DeletePerson(int PeopleID)
        {
            int num = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "Delete People \r\n                                where PeopleID = @PeopleID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PeopleID", PeopleID);
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
            string cmdText = "SELECT Found=1 FROM People WHERE PeopleID = @PeopleID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PeopleID", ID);
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
        public static bool IsPersonExist(string NationalNO)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT Found=1 FROM People WHERE PeopleID = @NationalNO";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@NationalNO", NationalNO);
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
}


