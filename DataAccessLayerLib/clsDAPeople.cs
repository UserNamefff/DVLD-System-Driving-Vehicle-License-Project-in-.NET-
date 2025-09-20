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

        public static bool GetPersonInfoByID(int PersonID , ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string Email, ref string Phon, ref int Address, ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath, ref string Gender,ref string NationalNO)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT * FROM People WHERE PersonID = @PersonID";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    result = true;
                    ThirdName = (string)sqlDataReader["ThirdName"];
                    FirstName = (string)sqlDataReader["FirstName"];
                    SecondName = (string)sqlDataReader["SecondName"];
                    //FullName = (FirstName +(string)sqlDataReader["SecondName"]+(string)sqlDataReader["ThirdName"] + (string)sqlDataReader["LastName"]).ToString();
                    LastName = (string)sqlDataReader["LastdName"];
                    Email = (string)sqlDataReader["Email"];
                    Phon = (string)sqlDataReader["Phon"];
                    Address = (int)sqlDataReader["Address"];
                    DateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                    CountryID = (int)sqlDataReader["CountryID"];
                    NationalNO = (string)sqlDataReader["NationalNO"];

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

        public static bool GetPersonInfoByName(string FirstName, ref int PersonID, ref string SecondName, ref string ThirdName, ref string LastName, ref string Email, ref string Phon, ref int Address, ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath, ref string Gender, ref string NationalNO)
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
                   // NationalNO = (int)sqlDataReader["NationalNO"];
                    ThirdName = (string)sqlDataReader["ThirdName"];
                    SecondName = (string)sqlDataReader["SecondName"];
                    //FullName = (FirstName +(string)sqlDataReader["SecondName"]+(string)sqlDataReader["ThirdName"] + (string)sqlDataReader["LastName"]).ToString();
                    LastName = (string)sqlDataReader["LastdName"];
                    Email = (string)sqlDataReader["Email"];
                    Phon = (string)sqlDataReader["Phon"];
                    Address = (int)sqlDataReader["Address"];
                    DateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                    CountryID = (int)sqlDataReader["CountryID"];
                    NationalNO = (string)sqlDataReader["NationalNO"];

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
        
        public static bool GetPersonInfoByNationalNumber(string NationalNO, ref int PersonID, ref string FirstName,  ref string SecondName, ref string ThirdName, ref string LastName, ref string Email, ref string Phon, ref int Address, ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath, ref string Gender)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT * FROM People WHERE NationalNO = @NationalNO";
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@NationalNO", NationalNO);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    result = true;
                    PersonID = (int)sqlDataReader["PersonID"];
                    ThirdName = (string)sqlDataReader["ThirdName"];
                    SecondName=(string)sqlDataReader["SecondName"];
                   //FullName = (FirstName +(string)sqlDataReader["SecondName"]+(string)sqlDataReader["ThirdName"] + (string)sqlDataReader["LastName"]).ToString();
                    LastName = (string)sqlDataReader["LastdName"];
                    Email = (string)sqlDataReader["Email"];              
                    Phon = (string)sqlDataReader["Phon"];                
                    Address = (int)sqlDataReader["Address"];
                    DateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                    CountryID = (int)sqlDataReader["CountryID"];
                    FirstName = (string)sqlDataReader["FirstName"];

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
            sqlCommand.Parameters.AddWithValue("@NationalNO", NationalNO);
            
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

        public static bool UpdatePerson(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string Email, string Phon, int Address, DateTime DateOfBirth, int CountryID, string ImagePath, string Gender,  string NationalNO)
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
      ,[ImagePath] = @ImagePath WHERE PersonID =@PersonID; ";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
           
            sqlCommand.Parameters.AddWithValue("@NationalNO", NationalNO);
            sqlCommand.Parameters.AddWithValue("@ThirdName", ThirdName);
            sqlCommand.Parameters.AddWithValue("@SecondName", SecondName);
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
            string cmdText = @"USE [DVLD] ;


SELECT [PersonID]
      ,[NationalNo]
      ,[FirstName]
      ,[SecondName]
      ,[ThirdName]
      ,[LastName]
      ,[DateOfBirth]
      ,[Gendor]
      ,[Address]
      ,[Phone]
      ,[Email]
      ,[NationalityCountryID]
      ,[ImagePath]
  FROM [dbo].[People]

";
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
            string cmdText = "Delete People \r\n                                where PersonID = @PersonID";
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

        public static bool IsPersonExist(int PersonID)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT Found=1 FROM People WHERE PersonID = @PersonID";
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
        
        public static bool IsPersonExist(string NationalNO)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "SELECT Found=1 FROM People WHERE NationalNO = @NationalNO";
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


