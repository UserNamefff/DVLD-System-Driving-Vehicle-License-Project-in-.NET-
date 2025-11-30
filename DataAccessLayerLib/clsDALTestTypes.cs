using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayerLib
{
    public class clsDALTestTypes
    {
       
            public static bool GetTestTypeByID(int TestTypeID, ref string TestTypeTitle,ref string TestTypeDescription, ref double ApplicationFees)
            {
                bool isFound = false;

                SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

                //string query = @"Select *from [dbo].TestTypes Where TestTypeID = @TestTypeID";
                string query = @"SELECT *
  FROM [dbo].[TestTypes] where
 TestTypeID = @TestTypeID";

                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    conn.Open();

                    SqlDataReader reader = comm.ExecuteReader();



                     // this line i attempted to read from reader without reader.Read()
                    if (reader.Read())
                    {
                        isFound = true;
                        TestTypeTitle = reader["TestTypeTitle"].ToString();
                        ApplicationFees = Convert.ToDouble(reader["TestTypeFees"]);
                        TestTypeDescription = (string)reader["TestTypeDescription"];
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
            //[TestTypeID]
            //[TestTypeTitle]
            //[ApplicationFees]
            public static int AddNewTestType(string TestTypeTitle,string TestTypeDescription , double ApplicationFees)
            {
                int TestTypeID = -1;

                SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = @"INSERT INTO [dbo].[TestTypes]
           ([TestTypeTitle]
           ,[TestTypeDescription]
           ,[TestTypeFees])
     VALUES
           (TestTypeTitle
           ,TestTypeDescription
           ,TestTypeFees)";

                SqlCommand comm = new SqlCommand(query, conn);

                try
                {
                    TestTypeID = comm.ExecuteNonQuery();
                    conn.Open();
                    //command.ExecuteNonQuery();

                    Object Resulte = comm.ExecuteScalar();

                    if (Resulte != null && int.TryParse(Resulte.ToString(), out int insertedID))
                    {
                        TestTypeID = insertedID;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    conn.Close();
                }

                return TestTypeID;
            }
            public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, double ApplicationFees)
            {
                bool isUpdate = false;
                SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = @"UPDAte  TestTypes SET  TestTypeTitle= @TestTypeTitle ,ApplicationFees = @ApplicationFees , TestTypeDescription =  @TestTypeDescription Where TestTypeID = @TestTypeID ";

                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
                command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);


                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
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
            public static DataTable GetAllTestTypes()
            {
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = @"Select *from [dbo].TestTypes ";

                SqlCommand comm = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = comm.ExecuteReader();

                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                        reader.Close();
                        conn.Close();

                        return dt;
                    }

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    conn.Close();
                }
                return null;
            }

    }
}
