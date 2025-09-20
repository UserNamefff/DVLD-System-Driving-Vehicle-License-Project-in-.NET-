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
    
    public class clsDACountries
    {

        public static bool GetCountryByID(int ID, ref string CountryName)
        {
            bool isFound = false;

            string Query = @"Select * From Countries where CountryID =@CountryID ";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(Query, conn);

            cmd.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;
                   // CountryCode = (string)Reader["CountryCode"];
                    CountryName = (string)Reader["CountryName"];

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static bool GetCountryByID(string CountryName, ref int ID)
        {
            bool isFound = false;

            string Query = @"Select * From Countries WHERE CountryName =@CountryName ";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(Query, conn);

            cmd.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;
                    ID = (int)Reader["CountryID"];
                    // CountryCode = (string)Reader["CountryCode"];

                }
                Reader.Close();

            }
            catch (SqlException ex)
            {

            }

            finally
            {
                conn.Close();
            }

            return isFound;
        }


        public static int AddNewCountry( string CountryName)
        {
            int CountyID = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            const string query = @"INSERT INTO Countries 
                                            VALUES (@CountryName); SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, conn);


            command.Parameters.AddWithValue("@CountryName", CountryName);


            try
            {
                conn.Open();
                //command.ExecuteNonQuery();

                Object Resulte = command.ExecuteScalar();

                if (Resulte != null && int.TryParse(Resulte.ToString(), out int insertedID))
                {
                    CountyID = insertedID;
                }
            }
            catch (Exception ex)
            {

            }

            finally
            {
                conn.Close();
            }

            return CountyID;
        }

        public static bool UpdateCountry(int CountryID, string CountryName)
        {
            bool isUpdate = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDAte  Countries SET CountryName = @CountryName Where CountryID = @CountryID ";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@CountryName", CountryName);


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


            return false;

        }

        public static bool IsExistCountry(int CountryID)
        {
            bool isFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found=1 FROM Countries WHERE CountryID =@CountryID ";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                

                isFound = reader.HasRows;

                reader.Close();
            }

            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static DataTable GetAllCountries()
        {
            DataTable tableOfCountries = new DataTable();
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * From Countries ";

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    tableOfCountries.Load(reader);
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

            return tableOfCountries;
        }

    }
}
