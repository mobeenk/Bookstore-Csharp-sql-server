using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cafeteria.DB_Helper
{
    public static class Connector
    {
       
        public static string connetionString { get; }  = @"Data Source= (localdb)\ProjectsV13 ;Initial Catalog=pubs; Integrated Security=True;";
      

        private const string DbName = "pubs";
        //private const string TblName = "jobs";
 
        public static DataSet readData(string TblName)
        {
            SqlConnection con = null;
            SqlDataAdapter adapter = null;
            DataSet ds = new DataSet();
            try
            {
                con = new SqlConnection();
                con.ConnectionString = connetionString;
                con.Open();
                //adapter = new SqlDataAdapter(" select* from dbo.titles where title like '" + TblName +" %' ", con);
                adapter = new SqlDataAdapter("Select * From " + TblName, con);
                adapter.Fill(ds, TblName);
            }
            catch (Exception ex)
            { MessageBox.Show("Cannot read the database."); }

            finally
            {
                if (con != null)
                {
                    con.Close();

                }
            }
            return ds;
        }

        public static DataSet searchBook(string parameter)
        {
            SqlConnection con = null;
            SqlDataAdapter adapter = null;
            DataSet ds = new DataSet();
            try
            {
                con = new SqlConnection();
                con.ConnectionString = connetionString;
                con.Open();
                adapter = new SqlDataAdapter("select * from titles where title like '"+parameter+ "%'   ", con);
               adapter.Fill(ds);
            }
            catch (Exception ex)
            { MessageBox.Show("Cannot read the database."); }

            finally
            {
                if (con != null)
                {
                    con.Close();

                }
            }
            return ds;
        }
        public static void updateCommand(string newCity, int store_id)
        {
            //var sql = " update stores set city = 'Jeddah' where stor_id = 6380";
            var sql = "UPDATE stores SET city = @city where stor_id = @store";// repeat for all variables
            try
            {
                using (var connection = new SqlConnection(connetionString))
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@city", SqlDbType.NVarChar).Value = newCity;
                        command.Parameters.Add("@store", SqlDbType.NVarChar).Value = store_id;
                        //command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = Lnamestring;
                        //command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = Fnamestring;
                        //command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Titelstring;
                        // repeat for all variables....
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("City has been updated  ");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to update. Error message: {e.Message}");
            }
      
        }
        public static void insertCommand(string newCity)
        {
            //string serial = RandomString(6);
            //string serial = "awdwadaw";
            var sql = "insert employee values ('"+RandomString(9)+"', '"+newCity+"', 'T', 'Cramer', 2, 215, '9952', '11/11/89' )";
            //var sql = "UPDATE stores SET city = @city where stor_id = 6380";// repeat for all variables
            try
            {
                using (var connection = new SqlConnection(connetionString))
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@city", SqlDbType.NVarChar).Value = newCity;
                        //command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = Lnamestring;
                        //command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = Fnamestring;
                        //command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Titelstring;
                        // repeat for all variables....
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("New Employee is added  ");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to update. Error message: {e.Message}");
            }

        }
        public static void deleteCommand(string newCity)
        {
         
            var sql = " delete from employee where emp_id = @serial  ";
            //var sql = "UPDATE stores SET city = @city where stor_id = 6380";// repeat for all variables
            try
            {
                using (var connection = new SqlConnection(connetionString))
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@serial", SqlDbType.NVarChar).Value = newCity;
                        //command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = Lnamestring;
                        //command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = Fnamestring;
                        //command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Titelstring;
                        // repeat for all variables....
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Employee has been deleted ");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to update. Error message: {e.Message}");
            }

        }
       
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }



    }
}
