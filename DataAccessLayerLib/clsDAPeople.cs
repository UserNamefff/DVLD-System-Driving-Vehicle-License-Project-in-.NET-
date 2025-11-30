using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace DVLD_DataAccessLayerLib
{

    public class clsDAPeople
    {

        
        public static bool GetPersonInfoByID(int PersonID , ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref int NationalityCountryID, ref string ImagePath, ref short Gendor,ref string NationalNO)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "USE [DVLD] ; SELECT * FROM [dbo].People WHERE PersonID = @PersonID";
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
                    
                    Email = (string)sqlDataReader["Email"];
                    Phone = (string)sqlDataReader["Phone"];
                    Address = (string)sqlDataReader["Address"];
                    DateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                    NationalityCountryID = (int)sqlDataReader["NationalityCountryID"];
                    NationalNO = (string)sqlDataReader["NationalNO"];
                    Gendor = Convert.ToInt16(sqlDataReader["Gendor"]);
                    
                    if(sqlDataReader["LastName"] != DBNull.Value)
                    {
                        LastName = (string)sqlDataReader["LastName"];
                    }
                    else
                    {
                        LastName = "USE [DVLD] ;";
                    }
                    if (sqlDataReader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)sqlDataReader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";;
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

        public static bool GetPersonInfoByName(string FirstName, ref int PersonID, ref string SecondName, ref string ThirdName, ref string LastName, ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref int NationalityCountryID, ref string ImagePath, ref short Gendor, ref string NationalNO)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "USE [DVLD] ;SELECT * FROM People WHERE FirstName = @FirstName";
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
                    LastName = (string)sqlDataReader["LastName"];
                    Email = (string)sqlDataReader["Email"];
                    Phone = (string)sqlDataReader["Phone"];
                    Address = (string)sqlDataReader["Address"];
                    DateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                    Gendor = Convert.ToInt16(sqlDataReader["Gendor"]);
                    NationalityCountryID = (int)sqlDataReader["NationalityCountryID"];
                    NationalNO = (string)sqlDataReader["NationalNO"];
                    PersonID = (int)sqlDataReader["PersonID"];

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
        
        public static bool GetPersonInfoByNationalNumber(string NationalNO, ref int PersonID, ref string FirstName,  ref string SecondName, ref string ThirdName, ref string LastName, ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref int NationalityCountryID, ref string ImagePath, ref short Gendor)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string cmdText = "USE [DVLD] ;SELECT * FROM People WHERE NationalNO = @NationalNO";
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
                    LastName = (string)sqlDataReader["LastName"];
                    Email = (string)sqlDataReader["Email"];              
                    Gendor = Convert.ToInt16(sqlDataReader["Gendor"]);              
                    Phone = (string)sqlDataReader["Phone"];                
                    Address = (string)sqlDataReader["Address"];
                    DateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                    NationalityCountryID = (int)sqlDataReader["NationalityCountryID"];
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

        public static int AddNewPerson(
    string FirstName, string SecondName, string ThirdName, string LastName,
    string Email, string Phone, string Address, DateTime DateOfBirth,
    int NationalityCountryID, string ImagePath, short Gendor, string NationalNo)
        {
            int result = -1;

            using (SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @" USE [DVLD];
        INSERT INTO [dbo].[People]   -- << change to [People] if your table is actually named People
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
        ,[NationalityCountryID]
        ,[ImagePath])
        VALUES
        (@NationalNo
        ,@FirstName
        ,@SecondName
        ,@ThirdName
        ,@LastName
        ,@DateOfBirth
        ,@Gendor
        ,@Address
        ,@Phone
        ,@Email
        ,@NationalityCountryID
        ,@ImagePath);

        SELECT SCOPE_IDENTITY();";


                //the error In this query doesn't exist @ placeholder in parameters Values -----------------
                //string query = @" INSERT INTO [dbo].[People] ([NationalNo] ,[FirstName] ,[SecondName] ,[ThirdName] ,[LastName] ,[DateOfBirth] ,[Gendor] ,[Address] ,[Phone] ,[Email] ,[NationalityCountryID] ,[ImagePath])
                //VALUES (NationalNo ,FirstName ,SecondName ,ThirdName ,LastName ,DateOfBirth ,Gendor ,Address ,Phone ,Email ,NationalityCountryID ,ImagePath); SELECT SCOPE_IDENTITY();";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NationalNo", NationalNo);
                    sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
                    sqlCommand.Parameters.AddWithValue("@SecondName", SecondName);
                    sqlCommand.Parameters.AddWithValue("@ThirdName", ThirdName);
                    sqlCommand.Parameters.AddWithValue("@LastName", LastName);
                    sqlCommand.Parameters.AddWithValue("@Email", Email);
                    sqlCommand.Parameters.AddWithValue("@Phone", Phone);
                    sqlCommand.Parameters.AddWithValue("@Address", Address);
                    sqlCommand.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    sqlCommand.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    sqlCommand.Parameters.AddWithValue("@Gendor", Gendor);

                    if (!string.IsNullOrEmpty(ImagePath))
                        sqlCommand.Parameters.AddWithValue("@ImagePath", ImagePath);
                    else
                        sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);

                    try
                    {
                        sqlConnection.Open();
                        object obj = sqlCommand.ExecuteScalar();
                        if (obj != null && int.TryParse(obj.ToString(), out int result2))
                        {
                            result = result2;
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Log the real SQL error for debugging
                        Console.WriteLine("SQL Error: " + ex.Message);
                    }
                }
            }

            return result;
        }

        public static bool UpdatePerson(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string Email, string Phone, string Address, DateTime DateOfBirth, int NationalityCountryID, string ImagePath, short Gendor,  string NationalNO)
        {
            int num = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"USE [DVLD]; UPDATE [dbo].[People]
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
      ,[NationalityCountryID] = @NationalityCountryID
      ,[ImagePath] = @ImagePath WHERE PersonID =@PersonID; ";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
           
            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
            sqlCommand.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            sqlCommand.Parameters.AddWithValue("@NationalNo", NationalNO);
            sqlCommand.Parameters.AddWithValue("@ThirdName", ThirdName);
            sqlCommand.Parameters.AddWithValue("@SecondName", SecondName);
            sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", LastName);
            sqlCommand.Parameters.AddWithValue("@Email", Email);
            sqlCommand.Parameters.AddWithValue("@Phone", Phone);
            sqlCommand.Parameters.AddWithValue("@Address", Address);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@Gendor", Gendor);
            
            if (ImagePath != "USE [DVLD] ;" && ImagePath != null)
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
            string cmdText = "USE [DVLD] ;USE [DVLD]; Delete People \r\n                                where PersonID = @PersonID";
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
            string cmdText = "USE [DVLD] ; SELECT Found=1 FROM People WHERE PersonID = @PersonID";
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
            string cmdText = @"USE [DVLD] ;


SELECT 
      [NationalNo]
      
  FROM [dbo].[People] Where [NationalNo] = @NationalNO

";
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


