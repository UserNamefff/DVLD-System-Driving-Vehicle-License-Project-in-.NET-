using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayerLib
{
    public class clsDALLincenseClasses
    {

      
            public static bool GetLicenseClassByID(int LicenseClassID, ref string ClassName,ref string ClassDescription, ref int MinimumAllowedAge,ref int DefaultValidityLength, ref double ClassFees)
            {
                bool isFound = false;

                SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

                //string query = @"Select *from [dbo].LicenseClasses Where ClassID = @ClassID";
                string query = @"SELECT *FROM [DVLD].[dbo].[LicenseClasses] where
                                    LicenseClassID = @LicenseClassID";

                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    conn.Open();

                    SqlDataReader reader = comm.ExecuteReader();

             
                

                    if (reader.Read())
                    {
                        isFound = true;
                        ClassName = reader["ClassName"].ToString();
                        ClassDescription = (string)reader["ClassDescription"];
                        ClassFees = Convert.ToDouble(reader["ClassFees"]);
                         DefaultValidityLength = Convert.ToInt32( reader["DefaultValidityLength"]);
                         MinimumAllowedAge = Convert.ToInt32(reader["MinimumAllowedAge"]);
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
        //[ClassID]
        //[ClassName]
        //[ClassFees]

        public static bool GetLicenseClassByClassName(  string ClassName,ref int LicenseClassID, ref string ClassDescription, ref int MinimumAllowedAge,
            ref int DefaultValidityLength, ref double ClassFees)
        {
            bool isFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //string query = @"Select *from [dbo].LicenseClasses Where ClassID = @ClassID";
            string query = @"SELECT *FROM [DVLD].[dbo].[LicenseClasses] where
                                    ClassName = @ClassName";

            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();


                if (reader.Read())
                {

                    isFound = true;
                    LicenseClassID = (int)reader["LicenseClassID"];
                    //ClassName = reader["ClassName"].ToString();
                    ClassDescription = (string)reader["ClassDescription"];
                    ClassFees = Convert.ToDouble(reader["ClassFees"]);
                    DefaultValidityLength = (int)reader["DefaultValidityLength"];
                    MinimumAllowedAge = (int)reader["MinimumAllowedAge"];
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
        

        public static int AddNewLicenseClass( string ClassName,  string ClassDescription, 
                 int MinimumAllowedAge,  int DefaultValidityLength,  double ClassFees)
            {
                int ClassID = -1;

                SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = @"Insert into LicenseClasses (ClassName,ClassDescription,MinimumAllowedAge,DefaultValidityLength,ClassFees) Values (@ClassName,@ClassDescription,@MinimumAllowedAge,@DefaultValidityLength,@ClassFees)";

                SqlCommand comm = new SqlCommand(query, conn);

                try
                {
                    ClassID = comm.ExecuteNonQuery();
                    conn.Open();
                    //command.ExecuteNonQuery();

                    Object Resulte = comm.ExecuteScalar();

                    if (Resulte != null && int.TryParse(Resulte.ToString(), out int insertedID))
                    {
                        ClassID = insertedID;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    conn.Close();
                }

                return ClassID;
            }


            public static bool UpdateLicenseClass(int LicenseClassID,  string ClassName,  string ClassDescription,
                 int MinimumAllowedAge,  int DefaultValidityLength,  double ClassFees)
            {
                bool isUpdate = false;
                SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = @"UPDAte  LicenseClasses SET  ClassName= @ClassName ,ClassFees = @ClassFees Where ClassID = @ClassID ";

                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("@ClassID", LicenseClassID);
                command.Parameters.AddWithValue("@ClassName", ClassName);
                command.Parameters.AddWithValue("@ClassFees", ClassFees);
                command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                command.Parameters.AddWithValue("@ClassFees", DefaultValidityLength);
           

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

        

            public static DataTable GetAllLicenseClasses()
            {
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = @"Select *from [dbo].LicenseClasses ";

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
